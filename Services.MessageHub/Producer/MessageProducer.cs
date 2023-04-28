using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.Net;

namespace Services.MessageHub.Producer
{
    public sealed class MessageProducer: IMessageProducer
    {
        private readonly ProducerConfig config;

        private readonly string topicName;

        public MessageProducer(MessageProducerConfig serviceConfig)
        {
            config = new ProducerConfig()
            {
                BootstrapServers = serviceConfig.BootstrapServers
            };

            topicName = serviceConfig.TopicName;
        }

        public async Task<string> ProduceAsync(string message)
        {
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var result = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
            }

            return message;
        }
    }
}
