using Blazored.Modal;
using Blazored.Modal.Services;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using BizHub.Components.Modals.ChatMessgae;
namespace BizHub.Components.MessageCenter
{
    public partial class CmpChatMessageMenu
    {
        #region Fields
        private PagAccountSetupController _controller = null;
        #endregion

        #region Methods
        public void OpenNewChat()
        {
            ShowNewChatModal();
        }
        public void OpenPersonalChatConnect()
        {
            ShowPersonalChatModal();
        }
        public void OpenGroupChatConnect()
        {
            ShowGroupChatModal();
        }
        async Task ShowNewChatModal()
        {
            ModalParameters oParameters = new ModalParameters();
            oParameters.Add("CHAT_USERS", CHAT_USERS);
            oParameters.Add("ModalHeader", "New Chat");
            //oParameters.Add("ModalSubHeader", "Add Buyer Detail");
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " business-category-modal modal-forward";
            oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpNewChatModal), "", oParameters, oOptions).Result;
            //if (BCModalResult.Cancelled)
            //{
            //    Console.WriteLine("Modal was cancelled");
            //}
            //else
            //{
            //    buyerDetail = (BuyerDetail)BCModalResult.Data;
            //    StateHasChanged();
            //}
        }

        async Task ShowPersonalChatModal()
        {
            ModalParameters oParameters = new ModalParameters();

            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " business-category-modal modal-forward";
            oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpPersonalChatConnectModal), "", oParameters, oOptions).Result;

        }

        async Task ShowGroupChatModal()
        {
            ModalParameters oParameters = new ModalParameters();
            //oParameters.Add("CHAT_USERS", CHAT_USERS);
            //oParameters.Add("ModalHeader", "Buyer");
            //oParameters.Add("ModalSubHeader", "Add Buyer Detail");
            FSBlazorModalOptions oOptions = new FSBlazorModalOptions();
            oOptions.HideCloseButton = true;
            oOptions.Class += " business-category-modal modal-forward";
            oOptions.HideHeader = true;
            ModalResult BCModalResult = await Controller.ShowModal(typeof(CmpGroupChatConnectModal), "", oParameters, oOptions).Result;
            //if (BCModalResult.Cancelled)
            //{
            //    Console.WriteLine("Modal was cancelled");
            //}
            //else
            //{
            //    buyerDetail = (BuyerDetail)BCModalResult.Data;
            //    StateHasChanged();
            //}
        }
        #endregion
        #region Properties
        public List<ChatUsers> CHAT_USERS = new List<ChatUsers> {
            new ChatUsers {Name = "Steven Grover ", Image = "/images/man-profile.jpg",History = "Chatted 2 months ago",Status="Online"},
            new ChatUsers {Name = "Flexin Saless", Image = "/images/man-1.jpg",History = "Chatted 4 months ago",Status="Active"},
            new ChatUsers {Name = "Mark Jeffords", Image = "/images/man-2.jpg",History = "Chatted 7 months ago",Status="InActive"},
            new ChatUsers {Name = "Sen jullie", Image = "/images/man-profile.jpg",History = "Chatted over a year ago",Status="Active"},
            new ChatUsers {Name = "Vivek Shah", Image = "/images/man-1.jpg",History = "Chatted over a year ago",Status="Online"},
            new ChatUsers {Name = "jenny ban", Image = "/images/woman-1.jpg",History = "Chatted over a year ago",Status="Online"},
            new ChatUsers {Name = "kyle rodz", Image = "/images/woman-1.jpg",History = "Chatted over a year ago",Status="InActive"},
        };
        [Parameter]
        public PagAccountSetupController Controller { get => _controller; set => _controller = value; }

        #endregion(Properties)

    }
}
