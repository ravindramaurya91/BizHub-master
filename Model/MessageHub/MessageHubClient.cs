using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

using CommonUtil;
using Model;

namespace Model {
    public delegate void ActiveGroupChangedHandler(object sender, ActiveGroupChangedEventArgs e);
    public delegate void ActiveChannelChangedHandler(object sender, ActiveChannelChangedEventArgs e);
    
    public class MessageHubClient  {

        #region Events
        public event ActiveGroupChangedHandler OnActiveGroupChanged;
        public event ActiveChannelChangedHandler OnActiveChannelChanged;
        #endregion (Events)

        #region Fields
        private Int64 _entityOid;
        private Int64 _entityOid_Master;
        private string _avatar;
        private IImageHierarchy _activeItem = null;
        protected Int64 _clientId = -1;

        protected TextChannelDTO _activeChannel = null;
        protected TextGroupDTO _activeGroup = null;
        private List<TextGroupDTO> _groups = new List<TextGroupDTO>();
        #endregion (Fields)

        #region Constructor
        public MessageHubClient() {
            BizHubUser oUser = SessionMgr.Instance.User;
            if (string.IsNullOrEmpty(oUser.Avatar)){
                oUser.LoadAvatar();
            }
            Initialize(oUser.EntityOid, oUser.EntityOid_Master, oUser.Avatar); 
        }
        public MessageHubClient(Int64 tiEntityOid, Int64 tiEntityOid_Master, string tsAvatar) {
            Initialize(tiEntityOid, tiEntityOid_Master, tsAvatar);
        }
        private void Initialize(Int64 tiEntityOid, Int64 tiEntityOid_Master, string tsAvatar) {
            _entityOid = tiEntityOid;
            _entityOid_Master = tiEntityOid_Master;
            _avatar = tsAvatar;

            LoadGroups();
            _clientId = MessageHub.Instance.RegisterClient(this);
        }
        #endregion (Constructor)

        #region Methods

        #region Events
        private void On_ActiveItemChanged() {
            if (_activeItem is TextGroupDTO) {
                ActiveGroup = (TextGroupDTO)_activeItem;
            } else {
                ActiveChannel = (TextChannelDTO)_activeItem;
            }
        }

        private void On_ActiveGroupChanged() {
            List<IImageHierarchy> oNextList;
            // This event will fire when the User selects a new TextGroup
            // We will see if the TextGroup has children or not - if so we will display the children in the left hand Accordian compponent
            if (_activeGroup.ChildrenLoaded) {
                // The Groups are all loaded at the instantiation of the Message Center.
                // If the Active Group is a Parent Group - its child groups will already be loaded.
                //
                // If the children are channels they may or may not be loaded.  If they are we will access them here without requerying, if they are not we will hit the "else" below

                oNextList = _activeGroup.Children;  // If there are TextGroupDTO children we will pass them to the event subscriber
            } else {
                // This TextGroup does not have any Child textGroups.  The UI will most likely want to display
                // the TextChannels that are within this TextGroup.  We will la load them now then throw an event to 
                // Any listener
                _activeGroup.LoadChannels(_entityOid);
                _activeGroup.Children = _activeGroup.Channels;
                _activeGroup.ChildrenLoaded = true;
                oNextList = _activeGroup.Channels;  // If there are TextGroupDTO children we will pass them to the event subscriber
            }

            // if not - we will get the TextChannels associated with the selected TextGroup;
            OnActiveGroupChanged?.Invoke(_activeGroup, new ActiveGroupChangedEventArgs(this, _activeItem, oNextList));
        }

        protected virtual void On_ActiveChannelChanged() {
            // If Active Channel is not null - load the messages for the channel
            if (_activeChannel != null) {
                _activeChannel.LoadMostRecentMessages();
                OnActiveChannelChanged?.Invoke(_activeItem, new ActiveChannelChangedEventArgs(this, _activeItem, _activeChannel));
            }
        }

        #endregion (Events)

        #region Group Mgt

        #region Create New Group
        protected TextGroup CreateNewGroup(string tsName, TextGroupDTO.eGroupLevel toLevel) {
            Int64? iParentGroupOid = null;
            return CreateNewGroup(tsName, toLevel, iParentGroupOid);
        }
        protected TextGroup CreateNewGroup(string tsName, TextGroupDTO.eGroupLevel toLevel, TextGroup toParentGroup) {
            Int64? iParentGroupOid = null;
            if (toParentGroup != null) {
                iParentGroupOid = toParentGroup.Oid;
            }
            return CreateNewGroup(tsName, toLevel, iParentGroupOid);
        }
        protected TextGroup CreateNewGroup(string tsName, TextGroupDTO.eGroupLevel toLevel, Int64? toParentGroupOid) {
            BizHubUser oLoggedInUser = SessionMgr.Instance.User;
            
            TextGroup oReturn = new TextGroup() {
                EntityOid_Master = _entityOid_Master, EntityOid = null,
                ParentOid = toParentGroupOid, HasMessages = false, HasUnreadMessages = false, IsExpanded = false, IsHidden = false, Name = tsName
            };

            // TextGroup records where EntityOid_Master == null are universally available for all users
            // Like "General Messages" and "Listings".  Any added with just EntityOid_Master will be available for everyone in the company
            // Any with EntityOid filled in will be Individual level Groups
            if(toLevel == TextGroupDTO.eGroupLevel.IndividualUserLevel) {
                oReturn.EntityOid = _entityOid;
            }

            // Sort 1 is reserved for "General Messages", Sort 2 is reserved for "Listings"
            // All new User created Groups will be Sort = 3
            // The groups will be ordered by (Sort then Name) so General Messages will always be first,
            // Listings will be second, then the User created Groups will be in Alpha order below "Listings"
            oReturn.Sort = 3;

            oReturn.Save();
            return oReturn;
        }
        #endregion (Create New Group)

        private void LoadGroups() {
            Groups = SQL.GetTextGroupDTOsByEntityOid_MasterAndEntityOid(_entityOid, _entityOid_Master);
        }

        private void SetActiveGroupByOid(Int64 tiGroupOid) {
            TextGroupDTO oGroup = GetGroupByOid(tiGroupOid);
            if(oGroup == null) {
                throw new Exception("Attempted to change the Active Group but not able to match the Group's Oid.");
            } else {
                ActiveGroup = oGroup;
            }
        }
        private TextGroupDTO GetGroupByOid(Int64 tiGroupOid) {
            TextGroupDTO oReturn = null;
            foreach(TextGroupDTO oItem in Groups) {
                oReturn = CheckGroupOid(oItem, tiGroupOid);
                if (oReturn != null) {
                    break;
                }
            }
            return oReturn;
        }
        private TextGroupDTO CheckGroupOid(TextGroupDTO toGroupDTO, Int64 tiGroupOid) {
            TextGroupDTO oReturn = null;
            if (toGroupDTO.Oid == tiGroupOid) {
                oReturn = toGroupDTO;
            } else {
                foreach(TextGroupDTO oChild in toGroupDTO.Children) {
                    oReturn = CheckGroupOid(oChild, tiGroupOid);
                    if(oReturn != null) {
                        break;
                    }
                }
            }
            return oReturn;
        }
        #endregion (Group Mgt)

        #region Channels Mgt
        public void CreateNewChannel(List<Entity> toEntities) {
            List<string> oNames = new List<string>() {SessionMgr.Instance.User.DisplayName};
            List<Int64> oOidList = new List<long>() { SessionMgr.Instance.User.EntityOid };
            foreach (Entity oEntity in toEntities) {
                oOidList.Add(oEntity.Oid);
                oNames.Add(oEntity.DisplayName);
            }
            oNames.Sort();  // Sort Alphabetically
            CreateNewChannel(oOidList, FSTools.ConvertListToDelimitedString(oNames, " - "));
        }

        public void CreateNewChannel(List<Int64> toRecipientOids, string tsName) {
            DateTime oDateStamp = DateTime.UtcNow;
            TextChannelDTO oNewChannel = new TextChannelDTO() { HasUnreadMessages = false, LastCommunicationDate = oDateStamp, Name = tsName, TextGroupOid = _activeGroup.Oid, Avatar = GetChannelAvatar(toRecipientOids) };
            oNewChannel.SaveNewChannel(toRecipientOids);
            ActiveChannel = oNewChannel;
        }

        public string GetChannelAvatar(List<Int64> toRecipientOids) {
            string sReturn;
            if(toRecipientOids.Count == 1) {
                // Needs to check if count == 2
                // If 2 grab the one that is NOT the current User
                Entity oEntity = SQL.GetEntityByOid(toRecipientOids[0], false);
                if (oEntity != null) {
                    sReturn = oEntity.Avatar;
                } else {
                    sReturn = Constants.DEFAULT_UNKNOWN_INDIVIDUAL_AVATAR;
                }
            } else {
                sReturn = Constants.DEFAULT_MULTI_RECIPIENT_AVATAR;
            }
            return sReturn;
        }
        public void RemoveChannel() {
            // Only removes the recipient from the channel - OptOut = true, 
            // Check for how many are still "in" if zero - remove the channel
        }
        #endregion (Channels Mgt)


        #region Message Mgt
        public void AddNewMessage(string tsMessage) {
            Int64 ilkpMessageType = LookupManager.Instance.GetOidByConstantValue("MESSAGETYPE->TEXTMESSAGE");

            TextMessageDTO oMsg = new TextMessageDTO() { DateSent = DateTime.UtcNow, lkpMessageTypeOid = ilkpMessageType, Message = tsMessage, MessageType = "Text", Avatar = _avatar, SentByOid = _entityOid, SentBy = SessionMgr.Instance.User.DisplayName, TextChannelOid = ActiveChannel.Oid };
            oMsg.Save();
            MessageHub.Instance.PostNewMessage(oMsg);
        }
        #endregion (Message Mgt)

        #endregion (Methods)

        #region Properties
        public Int64 ClientId { get => _clientId; set => _clientId = value; }
        public Int64 EntityId { get => _entityOid; set => _entityOid = value; }
        public List<TextGroupDTO> Groups { get => _groups; set => _groups = value; }

        public TextGroupDTO ActiveGroup {
            get { return _activeGroup; }
            protected set {
                if (_activeGroup != value) {
                    // User selected a different TextGroup
                    // Collapse the old one - Expand the new one - call the OnChanged event
                    if (_activeGroup != null) {
                        _activeGroup.IsExpanded = false;
                    }
                    _activeGroup = value;
                    _activeGroup.IsExpanded = true;

                    On_ActiveGroupChanged();
                }
            }
        }
        public TextChannelDTO ActiveChannel {
            get { return _activeChannel; }
            set {
                if (_activeChannel != value) {
                    if(_activeGroup.Oid != value.TextGroupOid) {
                        // We are changing Groups as well as Channels
                        SetActiveGroupByOid(value.TextGroupOid);
                    }
                    _activeChannel = value;
                    On_ActiveChannelChanged();
                }
            }
        }
        public Int64? ActiveChannelId {
            get {
                Int64? iReturn = null;
                if(_activeChannel != null) {
                    iReturn = _activeChannel.Oid;
                }
                return iReturn;
            }
        }

        public IImageHierarchy ActiveItem {
            get { return _activeItem; }
            set {
                if (_activeItem != value) {
                    // User selected a different TextGroup
                    // Collapse the old one - Expand the new one - call the OnChanged event
                    _activeItem = value;
                    On_ActiveItemChanged();
                }
            }
        }

        #endregion (Properties)
    }

    #region Event Handlers

    #region ActiveGroupChangedEventArgs
    public class ActiveGroupChangedEventArgs : EventArgs {
        #region Constructor
        public ActiveGroupChangedEventArgs(MessageHubClient toClient, IImageHierarchy toActiveItem, List<IImageHierarchy> toChildren) {
            MessageHubClient = toClient;
            ActiveItem = toActiveItem;
            Children = toChildren;
        }
        #endregion (Constructor)

        #region Properties
        public MessageHubClient MessageHubClient { get; set; }
        public IImageHierarchy ActiveItem { get; set; }
        public List<IImageHierarchy> Children { get; set; }
        #endregion (Properties)

    }
    #endregion (ActiveGroupChangedEventArgs)

    #region ActiveChannelChangedEventArgs
    public class ActiveChannelChangedEventArgs : EventArgs {
        #region Constructor
        public ActiveChannelChangedEventArgs(MessageHubClient toClient, IImageHierarchy toActiveItem, TextChannelDTO toChannel) {
            MessageHubClient = toClient;
            ActiveItem = toActiveItem;
            Channel = toChannel;
        }
        #endregion (Constructor)

        #region Properties
        public MessageHubClient MessageHubClient { get; set; }
        public IImageHierarchy ActiveItem { get; set; }
        public TextChannelDTO Channel { get; set; }
        #endregion (Properties)

    }
    #endregion (ActiveChannelChangedEventArgs)

    #endregion (Event Handlers)
}

