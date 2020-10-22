using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web;

namespace BizHub.Components.Modals.ChatMessgae
{
    public partial class CmpNewChatModal
    {
        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }
        #region Fields
        public List<ChatUsers> _AllUsers = null;
        public List<ChatUsers> _Chatusers = null;
        #endregion(Fields)

        #region Constructor
        protected override void OnInitialized()
        {
            ChatUsersObj = new ChatUsers();
            AllUsers = CHAT_USERS;
        }
        #endregion(Constructor)

        #region Methods

        public void Search(string Keyword)
        {
            //bool equal = CHAT_USERS.SequenceEqual(AllUsers);
            //if (equal)
            //{
                CHAT_USERS = new List<ChatUsers> {
            new ChatUsers {Name = "Steven Grover ", Image = "/images/man-profile.jpg",History = "Chatted 2 months ago",Status="Online"},
            new ChatUsers {Name = "Flexin Saless", Image = "/images/man-1.jpg",History = "Chatted 4 months ago",Status="Active"},
            new ChatUsers {Name = "Mark Jeffords", Image = "/images/man-2.jpg",History = "Chatted 7 months ago",Status="InActive"},
            new ChatUsers {Name = "Sen jullie", Image = "/images/man-profile.jpg",History = "Chatted over a year ago",Status="Active"},
            new ChatUsers {Name = "Vivek Shah", Image = "/images/man-1.jpg",History = "Chatted over a year ago",Status="Online"},
            new ChatUsers {Name = "jenny ban", Image = "/images/woman-1.jpg",History = "Chatted over a year ago",Status="Online"},
            new ChatUsers {Name = "kyle rodz", Image = "/images/woman-1.jpg",History = "Chatted over a year ago",Status="InActive"},
        };
            //}
            if (!string.IsNullOrEmpty(Keyword))
            {
                CHAT_USERS = CHAT_USERS.Where(x => x.Name.ToLower().Contains(Keyword.ToLower())).ToList();

                foreach (ChatUsers item in CHAT_USERS)
                {
                    var startHtml = string.Format("<span class=\"{0}\">", "profane");
                    var endHtml = "</span>";
                    string output = Regex.Replace(item.Name, Keyword,
          match => startHtml + match.Value + endHtml,
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

                    if (!string.IsNullOrEmpty(output))
                    {
                        item.Name = output;
                    }
                }
            }
        }

        #endregion(Methods)

        #region Properties
        public ChatUsers ChatUsersObj { get; set; }
        public List<ChatUsers> AllUsers { get => _AllUsers; set => _AllUsers = value; }

        [Parameter] public List<ChatUsers> CHAT_USERS { get => _Chatusers; set => _Chatusers = value; }
        [Parameter]
        public string SelectionTitle { get; set; } = "";
        [Parameter]
        public string ModalHeader { get; set; } = "";
        [Parameter]
        public string ModalSubHeader { get; set; }

        #endregion(Properties)
    }
}
