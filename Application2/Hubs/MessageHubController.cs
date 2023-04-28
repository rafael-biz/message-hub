using Application1.Hubs;
using Microsoft.AspNetCore.SignalR;
using Services.MessageHub.Consumer;

namespace Application2.Hubs
{
    public class MessageHubController : BackgroundService
    {
        private readonly IMessageConsumer consumer;

        private readonly IHubContext<MessageHub> hubContext;

        public MessageHubController(IMessageConsumer consumer, IHubContext<MessageHub> hubContext)
        {
            this.consumer = consumer;
            this.hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                string message = consumer.ReadFromBuffer();

                if (message == null)
                {
                    await Task.Delay(100);
                    continue;
                }

                await hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            }
        }
    }
}
