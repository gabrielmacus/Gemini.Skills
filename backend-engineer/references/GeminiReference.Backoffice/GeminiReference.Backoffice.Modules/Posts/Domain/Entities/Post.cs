using GeminiReference.Backoffice.Modules.Posts.Domain.Events;
using GeminiReference.Backoffice.Modules.Posts.Domain.Snapshots;
using GeminiReference.Backoffice.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Entities
{
    public class Post : AggregateRoot, ISnapshotable<Post, PostSnapshot>, IDeletable
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

        public static Post Create(Guid id, string title, string contents)
        {
            var post = new Post(id, title, contents);

            post.RecordDomainEvent(
                new PostCreatedEvent
                {
                    Contents = contents,
                    PostId = id,
                    Title = title,
                }
            );

            return post;
        }

        public void Update(string title, string contents)
        {
            Title = new PostTitle(title);
            Contents = new PostContents(contents);

            RecordDomainEvent(
                new PostUpdatedEvent
                {
                    PostId = Id.Value,
                    Title = title,
                    Contents = contents,
                }
            );
        }

        public void Delete()
        {
            RecordDomainEvent(new PostDeletedEvent { PostId = Id.Value });
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
