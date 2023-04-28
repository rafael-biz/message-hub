using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MessageHub.Producer
{
    public class MessageProducerConfig
    {
        public string BootstrapServers { get; set; }
        public string TopicName { get; set; }
    }
}
