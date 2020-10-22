using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BizHub.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Net.Http;
using Syncfusion.Blazor.Charts;
using Syncfusion.Blazor.Inputs;

using Model;
using CommonUtil;
using BizHub.Components.MessageCenter;
using Microsoft.AspNetCore.Components.Web;

using Microsoft.JSInterop;

namespace BizHub.Pages.MessageCenter {
    public partial class PagMessageCenter {


        #region Fields
        private PagMessageCenterController _controller;
        private TwilioVoice _twilioVoice = null;
        private string _myMessage = "";
        private bool _isNewChannelRender = false;
        #endregion (Fields)


        #region Constructor

        public PagMessageCenter() : base() {
            _controller = new PagMessageCenterController();
            _controller.OnSelectedTextGroupDTOChanged += _controller_OnActiveGroupChanged;
            _controller.OnSelectedTextChannelDTOChanged += _controller_OnActiveChannelChanged;
            _controller.OnSelectedTextMessageDTOChanged += _controller_OnActiveMessageChanged;
        }
        #endregion (Constructor)

        #region Methods
        protected override void OnAfterRender(bool firstRender) {
            if (firstRender) {
                Console.WriteLine("first time");
                if (CurrentMenu <= 0 || CurrentMenu == null) {
                    // Console.WriteLine(Controller.Groups[0].Oid);
                    SelectMenuItem(Controller.Groups[0].Oid);
                    if (Controller.Groups[0].Children.Count > 0) {
                        SelectItem(Controller.Groups[0].Children[0]);
                    }
                }

                if (_twilioVoice == null)
                {
                  //  _twilioVoice = new TwilioVoice(JSRuntime);
                }
            }
            if (IsNewChannelRender) {
                IsNewChannelRender = false;
                InvokeScroll();
            }
        }

        #region Active Group Changed
        private void _controller_OnActiveGroupChanged(object sender, ActiveGroupChangedEventArgs e) {
            // This event will fire when the User selects a new item from the Accordian. The inbound "sender" object will be a TextGroup. 
            // Its Children may be a list of Groups or a List of Channels depending on which Group is selected

            Debug.WriteLine($"The Selected Text Group is \"{ActiveGroup.Name}\"");

            List<IImageHierarchy> oNewHierarchyList = ActiveGroup.Children;  // We will display this list in the 

            if (oNewHierarchyList.Count > 0) {
                if (oNewHierarchyList[0] is TextChannelDTO) {
                    ActiveChannel = (TextChannelDTO)oNewHierarchyList[0];
                }
            }
        }
        #endregion (Active Group Changed)

        #region Active Channel Changed
        private void _controller_OnActiveChannelChanged(object sender, EventArgs e) {
            Debug.WriteLine($"The Selected Text Channel is \"{ActiveChannel.Name}\"");
            // This event will fire when the User selects a TextChannel 
            // If the TextChannelis not null -  the TextMessages associated will be passed here as the "sender" parameter

            // ********** SAMPLE CODE  *************************************
            TextChannelDTO oActiveChannel = (TextChannelDTO)sender;
            // If oMessages.Count > 0 we will display the Messages in the Message pad to the right of the Accordian Menu

            if (oActiveChannel.Messages.Count > 0) {
                // Here we are selecting to bottom (most recent) Message
                ActiveMessage = (oActiveChannel.Messages[oActiveChannel.Messages.Count - 1]);
            }

        }
        #endregion (Active Channel Changed)

        #region Active Message Changed
        private void _controller_OnActiveMessageChanged(object sender, EventArgs e) {
            IsNewChannelRender = true;
            // This event will fire when the user clicks on a specific message on the right side panel of 
            Debug.WriteLine($"The Selected Text Message is \"{ActiveMessage.Message}\"");
        }

        public void InvokeScroll() {
            jsRuntime.InvokeVoidAsync("ScrollToBottom", "ChatDiv");
            //StateHasChanged();
        }
        #endregion (Active Message Changed)


        #region Make an Outbound Phone Call
        public async void BeginOutboundPhoneCall() {
            string sPhoneNumber = "+12095957845";
            //string sPhoneNumber = "+919994242775";
            if (_twilioVoice == null) {
                _twilioVoice = new TwilioVoice(JSRuntime);
            }
            await _twilioVoice.InitiatePhoneCall(sPhoneNumber);
        }
        public async void EndOutboundPhoneCall() {
            if (_twilioVoice == null) {
                await _twilioVoice.EndPhoneCall();
            }
        }

        #endregion (Make an Outbound Phone Call)
        
        public void CheckForEnter(KeyboardEventArgs e) {
            if(e.Key.Equals("Enter"))
            {
                SendNewMessage(MyMessage);
            }
        }

        public void SendNewMessage(string tsMessage) {
            if (!string.IsNullOrEmpty(tsMessage))
            {
                try {
                    if (ActiveChannel != null) {
                        BizHubUser oUser = SessionMgr.Instance.User;
                        Int64 iMessageType = LookupManager.Instance.GetOidByConstantValue("MESSAGETYPE->TEXTMESSAGE");
                        TextMessage oNewMessage = new TextMessage() { DateSent = DateTime.UtcNow, lkpMessageTypeOid = iMessageType , Message = tsMessage, SentBy = oUser.DisplayName, SentByOid = oUser.EntityOid, TextChannelOid = ActiveChannel.Oid };
                        oNewMessage.Save();
                        TextMessageDTO oDTO = new TextMessageDTO(oNewMessage);
                        oDTO.Avatar = oUser.Avatar;
                        oDTO.MessageType = "Text Message";
                        ActiveChannel.Messages.Add(oDTO);
                        ActiveMessage = oDTO;
                        MyMessage = "";
                    } else {
                        throw new Exception("You are not current in a Text Channel.  Select one on the left and resend message.");
                    }
                }catch(Exception ex) {
                    // throw a Modal with the Exception Message
                } 
            }
        }
        //public List<TextGroupDTO> GetTextGroupList() {
        //    return _controller.GetTextGroupList();
        //}
        public void OnGroupSelected(IImageHierarchy toSelectedItem)
        {
            ActiveItem = toSelectedItem;
        }

        public void CreateNewChat(string tsObj)
        {
            
        }

        public void SendMessage()
        {
          
        }

        public void SelectMenuItem(Int64 menuNumber) {
            _controller.NavManager.NavigateTo("/Message-Center/" + menuNumber);
            CurrentMenu = menuNumber;
            Console.WriteLine(ActiveItem);
        }

        public void SelectItem(IImageHierarchy toItem) {
            Controller.ActiveItem = toItem;
        }
        // public List<TextGroupDTO> GetTextGroupList() {
        //     return _controller.GetTextGroupList();
        // }
        #endregion (Methods)

        #region Properties
        
        [Parameter] public long CurrentMenu { get; set; }
        
        public string MyMessage { get => _myMessage; set => _myMessage = value; }

        public TextGroupDTO ActiveGroup {
            get { return _controller.ActiveGroup; }
            set {_controller.ActiveItem = value; }  // Sets the ActiveItem which will update the ActiveTextGroup in the MessageHubClient
        }
        public TextChannelDTO ActiveChannel {
            get { return _controller.ActiveChannel; }
            set { _controller.ActiveItem = value; } // Sets the ActiveItem which will update the ActiveChannel in the MessageHubClient
        }
        public TextMessageDTO ActiveMessage {
            get { return _controller.ActiveMessage; }
            set { _controller.ActiveMessage = value; }
        }
        public IImageHierarchy ActiveItem { get => _controller.ActiveItem; set => _controller.ActiveItem = value; }
        public List<TextGroupDTO> Groups { get => _controller.Groups; }
        public PagMessageCenterController Controller { get =>_controller;}

        public string MyPhoneNumber { get; set; }
        public bool IsNewChannelRender { get => _isNewChannelRender; set => _isNewChannelRender = value; }
        #endregion (Properties)

        #region Unreviewed Indian Code
        [Inject] protected IJSRuntime JSRuntime { get; set; }
        private SfTextBox upload;

        //protected override async Task OnAfterRenderAsync(bool firstRender) {
        //}

        protected async Task InitiatePhoneCall(string tsPhoneNumber) {
            if(_twilioVoice == null) {
                _twilioVoice = new TwilioVoice(JSRuntime);
            }

            await _twilioVoice.InitiatePhoneCall(tsPhoneNumber);
            StateHasChanged();
        }

        protected async Task EndPhoneCall() {
            if (_twilioVoice == null) {
                await _twilioVoice.EndPhoneCall();
                StateHasChanged();
            }
        }


        public void onCreateUpload() {
            this.upload.AddIcon("prepend", "fas search-icon");
            this.upload.AddIcon("append", "fas phone-icon m-0 px-1 border-class");
        }

        #endregion (Unreviewed Indian Code)

    }
}
