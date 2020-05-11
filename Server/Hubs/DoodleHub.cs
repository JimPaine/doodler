using System;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using doodler.Client;

namespace doodler.Server.Hubs
{    
    public class DoodleHub : Hub
    {
        private readonly ILogger<DoodleHub> logger;

        public DoodleHub(ILogger<DoodleHub> logger)
        {
            this.logger = logger;
        }

        public async Task SendPayload(Payload payload)
        {
            await Clients.All.SendAsync("ReceivePayload", payload);
        }

        public async Task ClearCanvas()
        {
            await Clients.All.SendAsync("ClearCanvas");
        }
    }
}