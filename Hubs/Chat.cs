using Microsoft.AspNetCore.SignalR;
using Social_Media_App_Api_.Net_Core.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Social_Media_App_Api_.Net_Core.Hubs
{
    
    public class Chat : Hub
    {
        public async Task sendMessageToUser(string connectionId,string message)
        {
            await Clients.Client(connectionId).SendAsync(message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Connecteduser", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("DisConnecteduser", Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
