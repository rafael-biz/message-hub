namespace Services.MessageHub.Consumer
{
    public sealed class MessageConsumerConfig
    {
        public string BootstrapServers { get; set; }
        public string TopicName { get; set; }
    }
}
