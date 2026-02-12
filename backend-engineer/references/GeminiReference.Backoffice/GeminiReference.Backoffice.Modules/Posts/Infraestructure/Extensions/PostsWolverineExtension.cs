using GeminiReference.Integration.Backoffice.Posts.Events;
using GeminiReference.Integration.Backoffice.Posts.Snapshots;
using Neuraltech.SharedKernel.Infraestructure.Services;
using Wolverine;
using Wolverine.Kafka;

namespace GeminiReference.Backoffice.Modules.Posts.Infraestructure.Extensions
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

        private void ConfigurePostSnapshot(WolverineOptions options)
        {
            options
                .PublishMessage<PostPublicSnapshot>()
                .ToKafkaTopic(PostPublicSnapshot.PublicMessageName)
                .TopicCreation(
                    async (client, topic) =>
                    {
                        
                        await KafkaTopicManager.CreateOrUpdateTopic(
                            client,
                            topic.TopicName,
                            new Dictionary<string, string>
                            {
                                { "cleanup.policy", "compact" },
                                { "segment.ms", TimeSpan.FromDays(7).TotalMicroseconds.ToString() }
                            }
                        );
                    }
                )
                
                ;
        }

        public void Configure(WolverineOptions options)
        {
            ConfigurePostCreatedEvent(options);
            ConfigurePostUpdatedEvent(options);
            ConfigurePostDeletedEvent(options);
            ConfigurePostSnapshot(options);
        }
    }
}
