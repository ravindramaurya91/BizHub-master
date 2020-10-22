using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BizHub.Areas.Identity;
using BizHub.Services;
using BizSearch;
using Model;
using CommonUtil;

namespace BizHub {
    public class PagMessageCenterController : BasePageController {

        #region Events
        public event ActiveGroupChangedHandler OnSelectedTextGroupDTOChanged;
        public event ActiveChannelChangedHandler OnSelectedTextChannelDTOChanged;
        public event EventHandler OnSelectedTextMessageDTOChanged;
        #endregion (Events)

        #region Fields
        private MessageHubClient _messageHubClient = new MessageHubClient();
        //private TextGroupDTO _selectedTextGroupDTO = null;
        private TextChannelDTO _selectedTextChannelDTO = null;
        private TextMessageDTO _selectedTextMessageDTO = null;
        private List<TextMessageDTO> _messages = new List<TextMessageDTO>();
        #endregion (Fields)

        #region Constructor
        public PagMessageCenterController() {
            _messageHubClient.OnActiveGroupChanged += _messageHubClient_OnActiveGroupChanged;
            _messageHubClient.OnActiveChannelChanged += _messageHubClient_OnActiveChannelChanged;
        }

        private void _messageHubClient_OnActiveGroupChanged(object sender, ActiveGroupChangedEventArgs e) {
            OnSelectedTextGroupDTOChanged?.Invoke(this.ActiveGroup.Children, e);
        }

        private void _messageHubClient_OnActiveChannelChanged(object sender, ActiveChannelChangedEventArgs e) {
            OnSelectedTextChannelDTOChanged?.Invoke(this.ActiveChannel, null);
        }
        #endregion (Constructor)

        #region Methods
        #region Events

        public void On_SelectedTextChannelDTOChanged() {
            // This event will fire when the User selects a new TextChannel
            // Load the associated TextMessages
            _messages = _selectedTextChannelDTO.Messages;
            // if not - we will get the TextChannels associated with the selected TextGroup;
            OnSelectedTextChannelDTOChanged?.Invoke(_messages, null);
        }
        public void On_SelectedTextMessageDTOChanged() {
            OnSelectedTextMessageDTOChanged?.Invoke(_selectedTextMessageDTO, null);
        }
        
        #endregion (Events)

        //public List<TextGroupDTO> GetTextGroupList() {
        //    return SQL.GetTextGroupDTOsByEntityOid_MasterAndEntityOid(_loggedInUser.EntityOid, _loggedInUser.EntityOid_Master);
        //}
        #endregion (Methods)

        #region Properties
        public MessageHubClient MessageHubClient { get => _messageHubClient; }
        public IImageHierarchy ActiveItem { get => _messageHubClient.ActiveItem; 
            set => _messageHubClient.ActiveItem = value; }

        public TextGroupDTO ActiveGroup { get => _messageHubClient.ActiveGroup;  }

        public TextChannelDTO ActiveChannel { get => _messageHubClient.ActiveChannel;  }


        public TextMessageDTO ActiveMessage {
            get { return _selectedTextMessageDTO; }
            set {
                if (_selectedTextMessageDTO != value) {
                    // User selected a different TextMessage  -  call the OnChanged event
                    _selectedTextMessageDTO = value;
                    On_SelectedTextMessageDTOChanged();
                }
            }
        }
        public List<TextMessageDTO> Messages { get => _messages; }
        public List<TextGroupDTO> Groups { get => _messageHubClient.Groups; }
        #endregion (Properties)

    }
}
