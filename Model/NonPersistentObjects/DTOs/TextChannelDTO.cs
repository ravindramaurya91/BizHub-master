using PetaPoco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model {
    public class TextChannelDTO : TextChannel, IImageHierarchy{

        #region Fields
        private List<IImageHierarchy> _children = new List<IImageHierarchy>();
        private List<TextMessageDTO> _messages = new List<TextMessageDTO>();
        private IImageHierarchy _parent = null;
        private bool _isSelected = false;
        private bool _isExpanded = false;
        #endregion (Fields)

        #region Methods
        public void SaveNewChannel(List<Int64> toRecipientOids) {
            base.Save(); // Save the TextChannel object

            TextRecipient oRecipient;

            // Create a TextRecipient record for each Recipient in the list (including the author)
            foreach (Int64 tiRecipientOid in toRecipientOids) {
                oRecipient = new TextRecipient() { EntityOid = tiRecipientOid, IsInvite = false, OptOut = false, Rsvp = false, TextChannelOid = this.Oid, ChannelName = "Channel Name TBD" };
                oRecipient.Save();
            }
        }
        
        public void LoadMostRecentMessages() {
            _messages = SQL.GetTextMessageDTOsByTextChannelOid_Last20(this.Oid);
        }
        public void LoadAllMessages() {
            _messages = SQL.GetTextMessageDTOsByTextChannelOid_All(this.Oid);
        }
        #endregion (Methods)

        #region Properties
        [Ignore] public DateTime Date { get; set; }
        [Ignore] public bool IsSelected { get => _isSelected; set => _isSelected = value; }
        [Ignore] public string Value { get; set; }
        [Ignore] public IImageHierarchy Parent {
            get { return _parent; }
            set { _parent = value; }
        }
        [Ignore] public List<IImageHierarchy> Children {
            get { return _children; }
            set { _children = value; }
        }
        [Ignore] public List<TextMessageDTO> Messages { get => _messages; set => _messages = value; }
        #endregion (Properties)
    }
}
