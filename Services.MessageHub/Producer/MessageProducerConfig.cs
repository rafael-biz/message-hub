namespace Services.MessageHub.Producer
{
    public class MessageProducerConfig
    {
        public string BootstrapServers { get; set; }
        public string TopicName { get; set; }
    }
}
