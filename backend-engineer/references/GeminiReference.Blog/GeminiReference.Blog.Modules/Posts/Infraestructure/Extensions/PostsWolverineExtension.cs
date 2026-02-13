using GeminiReference.Integration.Backoffice.Posts.Snapshots;
using System;
using System.Collections.Generic;
using System.Text;
using Wolverine;
using Wolverine.Kafka;

namespace GeminiReference.Blog.Modules.Posts.Infraestructure.Extensions
{
    public class PostsWolverineExtension : IWolverineExtension
    {
        private void ConfigurePostSnapshot(WolverineOptions options)
        {

            options
                .ListenToKafkaTopic(PostSnapshot.PublicSnapshotName);

        }
        public void Configure(WolverineOptions options)
        {
            ConfigurePostSnapshot(options);
        }
    }
}
