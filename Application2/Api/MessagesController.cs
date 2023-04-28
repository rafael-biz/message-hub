using Microsoft.AspNetCore.Mvc;
using Services.MessageHub.Producer;

namespace Application2.Api
{
    [Route("api/messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageProducer messageProducer;

        public MessagesController(IMessageProducer messageProducer)
        {
            this.messageProducer = messageProducer;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MessageDTO dto)
        {
            await messageProducer.ProduceAsync(dto.Message);

            return Ok();
        }
    }
}
