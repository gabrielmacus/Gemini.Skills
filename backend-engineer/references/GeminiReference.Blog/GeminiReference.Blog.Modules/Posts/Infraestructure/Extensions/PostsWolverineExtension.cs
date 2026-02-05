using GeminiReference.Integration.Blog.Posts.Events;
using Neuraltech.SharedKernel.Infraestructure.Services;
using Wolverine;
using Wolverine.Kafka;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Extensions
{
    public class PostsWolverineExtension : IWolverineExtension
    {
        private void ConfigurePostCreatedEvent(WolverineOptions options)
        {
            options
                .PublishMessage<PostCreatedIntegrationEvent>()
                .ToKafkaTopic(PostCreatedIntegrationEvent.PublicMessageName)
                .TopicCreation(
                    async (client, topic) =>
                    {
                        await KafkaTopicManager.CreateOrUpdateTopic(
                            client,
                            topic.TopicName,
                            new Dictionary<string, string>
                            {
                                {
                                    "retention.ms",
                                    TimeSpan.FromHours(1).TotalMilliseconds.ToString()
                                },
                                { "cleanup.policy", "delete" },
                            }
                        );
                    }
                );
        }

        private void ConfigurePostUpdatedEvent(WolverineOptions options)
        {
            options
                .PublishMessage<PostUpdatedIntegrationEvent>()
                .ToKafkaTopic(PostUpdatedIntegrationEvent.PublicMessageName)
                .TopicCreation(
                    async (client, topic) =>
                    {
                        await KafkaTopicManager.CreateOrUpdateTopic(
                            client,
                            topic.TopicName,
                            new Dictionary<string, string>
                            {
                                {
                                    "retention.ms",
                                    TimeSpan.FromHours(1).TotalMilliseconds.ToString()
                                },
                                { "cleanup.policy", "delete" },
                            }
                        );
                    }
                );
        }

        private void ConfigurePostDeletedEvent(WolverineOptions options)
        {
            options
                .PublishMessage<PostDeletedIntegrationEvent>()
                .ToKafkaTopic(PostDeletedIntegrationEvent.PublicMessageName)
                .TopicCreation(
                    async (client, topic) =>
                    {
                        await KafkaTopicManager.CreateOrUpdateTopic(
                            client,
                            topic.TopicName,
                            new Dictionary<string, string>
                            {
                                {
                                    "retention.ms",
                                    TimeSpan.FromHours(1).TotalMilliseconds.ToString()
                                },
                                { "cleanup.policy", "delete" },
                            }
                        );
                    }
                );
        }

        public void Configure(WolverineOptions options)
        {
            ConfigurePostCreatedEvent(options);
            ConfigurePostUpdatedEvent(options);
            ConfigurePostDeletedEvent(options);
        }
    }
}
