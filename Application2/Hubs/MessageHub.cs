using Microsoft.AspNetCore.SignalR;

namespace Application1.Hubs
{
    public class MessageHub : Hub
    {
        /// <summary>
        /// Sends a broadcast message for web clients.
        /// </summary>
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
