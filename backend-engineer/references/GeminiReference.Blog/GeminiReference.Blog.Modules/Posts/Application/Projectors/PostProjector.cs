using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using GeminiReference.Integration.Backoffice.Posts.Snapshots;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Application.Projectors;
using Neuraltech.SharedKernel.Domain.Contracts;
using Wolverine;

namespace GeminiReference.Blog.Modules.Posts.Application.Projectors
{
    public class PostProjector : 
        SnapshotProjector<PostSnapshot, Post>, 
        IWolverineHandler
    {
        public PostProjector(
            IPostRepository repository,
            IUnitOfWork unitOfWork, 
            ILogger<PostProjector> logger
        ) : base(repository, repository, repository, unitOfWork, logger)
        {
        }

        public override ValueTask<Post> ProjectEntity(PostSnapshot snapshot)
        {
            return ValueTask.FromResult(
                new Post(
                    snapshot.PostId, 
                    snapshot.Title, 
                    snapshot.Contents
                )
            );
        }

    }
}
