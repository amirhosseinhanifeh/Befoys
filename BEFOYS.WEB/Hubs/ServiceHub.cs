﻿using BEFOYS.Common.AppUser;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFOYS.WEB.Hubs
{
    public class ServiceHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.Identity.UserID();
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string user, string message)
        {
            var userId = Context.User.Identity.UserID();
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

    }
}
