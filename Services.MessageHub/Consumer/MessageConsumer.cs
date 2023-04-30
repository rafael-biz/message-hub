using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using System.Collections.Concurrent;

namespace Services.MessageHub.Consumer
{
    /// <summary>
    /// Starts a background service that consumes messages from kafka.
    /// </summary>
    public sealed class MessageConsumer: BackgroundService, IMessageConsumer
    {
        private readonly MessageConsumerConfig config;

        private readonly ConcurrentQueue<string> buffer = new ConcurrentQueue<string>();

        public MessageConsumer(MessageConsumerConfig config)
        {
            this.config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // Unfortunately Kafka doesn't have a non-blocking method to consume messages.
            await Task.Run(() => Execute(cancellationToken)).ConfigureAwait(false);
        }

        private void Execute(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumerConfig = new ConsumerConfig
                {
                    BootstrapServers = config.BootstrapServers,
                    GroupId = Guid.NewGuid().ToString("D"),
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

                consumer.Subscribe(config.TopicName);

                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume(TimeSpan.FromSeconds(1));

                    if (consumeResult != null && consumeResult.Message != null)
                    {
                        buffer.Enqueue(consumeResult.Message.Value);
                    }
                }

                consumer.Close();
            }
        }

        public string ReadFromBuffer()
        {
            buffer.TryDequeue(out var result);

            return result;
        }
    }
}
