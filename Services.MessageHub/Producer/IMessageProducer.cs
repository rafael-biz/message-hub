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
