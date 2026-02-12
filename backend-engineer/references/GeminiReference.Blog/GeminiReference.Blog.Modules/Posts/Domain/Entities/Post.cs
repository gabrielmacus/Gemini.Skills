using GeminiReference.Blog.Modules.Posts.Domain.Snapshots;
using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Blog.Modules.Posts.Domain.Entities
{
    public class Post : AggregateRoot, ISnapshotable<Post, PostSnapshot>
    {
        public PostTitle Title { get; private set; }
        public PostContents Contents { get; private set; }

        public Post(Guid id, string title, string contents)
            : base(new PostId(id))
        {
            Id = new PostId(id);
            Title = new PostTitle(title);
            Contents = new PostContents(contents);
        }

        public PostSnapshot ToSnapshot() =>
            new()
            {
                Id = Id.Value,
                Title = Title.Value,
                Contents = Contents.Value,
            };

        public static Post FromSnapshot(PostSnapshot snapshot) =>
            new Post(snapshot.Id, snapshot.Title, snapshot.Contents);
    }
}
