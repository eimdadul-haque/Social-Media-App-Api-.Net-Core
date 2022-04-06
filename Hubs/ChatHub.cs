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
        public async Task sendMessageToUser(string connectionId,string message)
        {
            await Clients.Client(connectionId).SendAsync(message);
        }

        public async Task sendMessageToCaller(string message)
        {
            await Clients.Caller.SendAsync(message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Active", Context.ConnectionId, Context.User.Identity.Name);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var item = ConnectedUser.Ids.SingleOrDefault(x => x.Id == Context.ConnectionId);
            if (item != null)
                ConnectedUser.Ids.Remove(item);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
