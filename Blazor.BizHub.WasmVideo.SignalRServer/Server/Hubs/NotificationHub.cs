using Blazor.BizHub.WasmVideo.SignalRServer.Shared;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace Blazor.BizHub.WasmVideo.SignalRServer.Server.Hubs
{
    public class NotificationHub : Hub
    {
        public Task RoomsUpdated(string room) =>
            Clients.All.SendAsync(HubEndpoints.RoomsUpdated, room);
    }
}
