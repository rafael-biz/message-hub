using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MessageHub.Producer
{
    public interface IMessageProducer
    {
        /// <summary>
        /// Produces a broadcast message.
        /// </summary>
        public Task<string> ProduceAsync(string message);
    }
}
