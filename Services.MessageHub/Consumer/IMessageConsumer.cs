namespace Services.MessageHub.Consumer
{
    public interface IMessageConsumer
    {
        /// <summary>
        /// Reads a message from the buffer.
        /// </summary>
        /// <returns>
        /// Returns null if there is no message in the buffer.
        /// </returns>
        public string ReadFromBuffer();
    }
}
