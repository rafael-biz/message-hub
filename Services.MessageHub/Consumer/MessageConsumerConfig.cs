using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MessageHub.Consumer
{
    public sealed class MessageConsumerConfig
    {
        public string BootstrapServers { get; set; }
        public string TopicName { get; set; }
        public string ConsumerGroupName { get; set; }
    }
}
