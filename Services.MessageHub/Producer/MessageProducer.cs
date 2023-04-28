using Confluent.Kafka;

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
            // This code could be optimized to reuse the connection.
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var result = await producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
            }

            return message;
        }
    }
}
