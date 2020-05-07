using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using doodler.Client;

namespace doodler.Server.Hubs
{
    public class DoodleHub : Hub
    {
        public async Task SendPayload(Payload payload)
        {
            await Clients.All.SendAsync("ReceivePayload", payload);
        }
    }
}