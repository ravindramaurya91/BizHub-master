using BizHub.FSLibrary.Messaging;
using Microsoft.AspNetCore.SignalR;
using Syncfusion.Blazor.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHub.Server.Messaging.Hubs {
    public class ChatHub : Hub {
        private static readonly Dictionary<string, string> userLookup = new Dictionary<string, string>();

        public async Task SendMessage(string sUsername, string sMessage) {
            await Clients.All.SendAsync(Messages.RECIEVE, sUsername, sMessage);
        }
        public async Task Register(string sUsername) {
            var currentId = Context.ConnectionId;
            if (!userLookup.ContainsKey(currentId)) {
                userLookup.Add(currentId, sUsername);
                await Clients.AllExcept(currentId).SendAsync(
                    Messages.RECIEVE, 
                    sUsername, $"{sUsername} joined the chat"
                    );
            }
        }

        public override Task OnConnectedAsync() {
            Console.Write("Connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex) {
            Console.Write($"Disconnected {ex?.Message} {Context.ConnectionId}");
            string id = Context.ConnectionId;
            if (!userLookup.TryGetValue(id, out string sUsername)) {
                sUsername = "[unknown]";
            }

            userLookup.Remove(id);
            await Clients.AllExcept(Context.ConnectionId).SendAsync(
                Messages.RECIEVE,
                sUsername, $"{sUsername} has left the chat"
                );
            await base.OnDisconnectedAsync(ex);
        }
    }
}
