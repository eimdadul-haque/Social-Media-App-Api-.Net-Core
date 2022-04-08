using Microsoft.AspNetCore.SignalR;
using Social_Media_App_Api_.Net_Core.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace Social_Media_App_Api_.Net_Core.Hubs
{

    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IHttpContextAccessor _context;

        public ChatHub(IHttpContextAccessor context)
        {
            _context = context;
        }
        public async Task sendMessageToUser(string connectionId, string userName, string message)
        {
            await Clients.Client(connectionId).SendAsync("ToId", userName, message);
        }

        public async Task sendMessageToCaller(string userName, string message)
        {
            await Clients.Caller.SendAsync("ToCaller", userName, message);
        }


        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Active", Context.ConnectionId, Context.User?.Identity?.Name);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("InActive", Context.ConnectionId, Context.User?.Identity?.Name);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
