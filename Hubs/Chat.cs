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
        //[Authorize]

        public async Task SendMessage(string msg)
        {
            await Clients.All.SendAsync("chat", msg);
        }

        public async Task user(string userName)
        {
            await Clients.All.SendAsync("chat", userName);
        }

        //[Authorize]

        public override Task OnConnectedAsync()
        {
           // ActiveUser.active_use.Add(Context.ConnectionId, User.identity.name);
            return base.OnConnectedAsync();
        }
    }
}
