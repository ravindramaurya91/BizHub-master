using BizHub.FSLibrary.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Components.AccountComponents {
    public partial class CmpUserMessageCenter {

        #region (Fields)

        #endregion (Fields)

        #region (Methods)
        async Task Chat() {
            if (string.IsNullOrWhiteSpace(username)) {
                message = "Please enter a name";
                return;
            }

            try {
                messages.Clear();
                client = new ChatClient(username, navigationManager);
                client.MessageReceived += MessageReceived;
                Console.WriteLine("Index:chat starting...");
                await client.StartAsync();
                Console.WriteLine("Index:chat starting?");
            } catch (Exception ex) {
                message = $"ERROR: Failed to start chat {ex.Message}";
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

            }
        }

        void MessageReceived(object oSender, MessageReceivedEventArgs e) {
            Console.WriteLine($"Blazor: receive {e.Username} : {e.Message}");
            bool IsMine = false;
            if (!string.IsNullOrWhiteSpace(e.Username)) {
                IsMine = string.Equals(e.Username, username, StringComparison.CurrentCultureIgnoreCase);
            }
            var newMsg = new Message(e.Username, e.Message, IsMine);
            messages.Add(newMsg);
            StateHasChanged();
        }

        async Task DisconnectAsync() {
            if (chatting) {
                await client.StopAsync();
                client = null;
                message = "chat ended";
                chatting = false;
            }
        }

        async Task SendAsync() {
            if (chatting && !string.IsNullOrWhiteSpace(newMessage)) {
                await client.SendAsync(newMessage);
                newMessage = "";
            }
        }
        #endregion (Methods)


        #region (Properties)
        bool chatting = false;
        string username = null;
        ChatClient client = null;
        string message = null;
        string newMessage = null;
        List<Message> messages = new List<Message>();

        #endregion (Properties)
    }

    class Message {
        public Message(string sUsername, string sBody, bool bMine) {
            Username = sUsername;
            Body = sBody;
            Mine = bMine;
        }
        public string Username { get; set; }
        public string Body { get; set; }
        public bool Mine { get; set; }

        public string CSS {
            get { return Mine ? "sent" : "received"; }
        }
    }
}
