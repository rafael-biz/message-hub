using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.MessageHub.Consumer;
using Services.MessageHub.Producer;

namespace Services.MessageHub
{
    public static class MessageHubExtensions
    {
        public static void AddMessageHub(this IServiceCollection services, IConfiguration configuration)
        {
            MessageConsumerConfig consumerConfig = configuration.Get<MessageConsumerConfig>();
            MessageProducerConfig producerConfig = configuration.Get<MessageProducerConfig>();

            services.AddSingleton<MessageConsumer>();
            services.AddHostedService(provider => provider.GetService<MessageConsumer>());
            services.AddSingleton<IMessageConsumer>(provider => provider.GetService<MessageConsumer>());
            services.AddSingleton(consumerConfig);

            services.AddSingleton<IMessageProducer, MessageProducer>();
            services.AddSingleton(producerConfig);
        }
    }
}
