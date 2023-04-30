using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.MessageHub;
using Services.MessageHub.Consumer;
using Services.MessageHub.Producer;

namespace TestProject
{
    [TestClass]
    public class ProducerConsumerTest
    {
        private IHost host;
        private IMessageProducer messageProducer;
        private IMessageConsumer messageConsumer;

        [TestInitialize]
        public async Task TestInitialize()
        {
            this.host = Host.CreateDefaultBuilder()
                .ConfigureHostConfiguration(configs =>
                {
                    var clientConfig = new ClientConfig();
                    clientConfig.Set("bootstrap.servers", "localhost:9200");
                    clientConfig.Set("test.mock.num.brokers", "1");
                    var adminClient = new AdminClientBuilder(clientConfig).Build();
                    var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(1));
                    string bootstrapServers = string.Join(",", metadata.Brokers.Select(b => $"{b.Host}:{b.Port}"));

                    configs.AddInMemoryCollection(new Dictionary<string, string>() {
                        { "BootstrapServers", bootstrapServers },
                        { "TopicName", "messages" }
                    });
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddMessageHub(context.Configuration);
                }).Build();

            this.messageProducer = host.Services.GetService<IMessageProducer>();
            this.messageConsumer = host.Services.GetService<IMessageConsumer>();
        }

        [TestMethod]
        public async Task TestProduceAsync()
        {
            string expected = Guid.NewGuid().ToString("D");

            await messageProducer.ProduceAsync(expected);

            await host.StartAsync();

            bool found = false;
            for (int i = 0; i < 10; i++)
            {
                string message = messageConsumer.ReadFromBuffer();
                if (message == null)
                {
                    await Task.Delay(1000);
                    continue;
                }

                Assert.AreEqual(expected, message);

                if (found = (message == expected))
                {
                    break;
                }
            }

            Assert.IsTrue(found, "Message not found.");
        }
    }
}