using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BizHub.FSLibrary.Messaging {
    public class ChatClient : IAsyncDisposable{
        public const string HUBURL = "/ChatHub";
        private readonly NavigationManager _navigationManager;
        private HubConnection _hubConnection;
        private readonly string _username;
        private bool _started = false;

        public ChatClient(string sUsername, NavigationManager oNavigationManager) {
            _navigationManager = oNavigationManager;
            _username = sUsername;
        }

        public async Task StartAsync() {
            if (!_started) {
                _hubConnection = new HubConnectionBuilder()
                                 .WithUrl(_navigationManager.ToAbsoluteUri(HUBURL))
                                 .Build();

                Console.WriteLine("ChatClient:calling Start()");

                _hubConnection.On<string, string>(Messages.RECIEVE, (user, message) => {
                    HandleReceiveMessage(user, message);
                });
                await _hubConnection.StartAsync();
                Console.WriteLine("ChatClient:Start Returned");
                _started = true;

                await _hubConnection.SendAsync(Messages.REGISTER, _username);
            }
        }

        private void HandleReceiveMessage(string sUsername, string sMessage) {
            MessageReceived?.Invoke(this, new MessageReceivedEventArgs(sUsername, sMessage));
        }

        public event MessageReceivedEventHandler MessageReceived;
        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);


        public async Task SendAsync(string sMessage) {
            if (!_started) {
                throw new InvalidOperationException("Client not started");
            }
            await _hubConnection.SendAsync(Messages.SEND,_username, sMessage);
        }

        public async Task StopAsync() {
            if (_started) {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
                _started = false;
            }
        }

        public async ValueTask DisposeAsync() {
            Console.WriteLine("ChatClient:Disposing");
            await StopAsync();
        }
    }

    public class MessageReceivedEventArgs : EventArgs {
        public string Username { get; set; }
        public string Message { get; set; }
        public MessageReceivedEventArgs(string sUsername, string sMessage) {
            Username = sUsername;
            Message = sMessage;
        }
    }
}
