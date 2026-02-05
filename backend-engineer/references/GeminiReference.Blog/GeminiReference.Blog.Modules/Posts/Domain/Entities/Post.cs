using GeminiReference.Blog.Modules.Posts.Domain.Events;
using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Blog.Modules.Posts.Domain.Entities
{
    public class Post : AggregateRoot
    {
        public PostTitle Title { get; private set; }
        public PostContents Contents { get; private set; }

        public Post(Guid id, string title, string contents) : base(new PostId(id))
        {
            Id = new PostId(id);
            Title = new PostTitle(title);
            Contents = new PostContents(contents);
        }

        public static Post Create(Guid id, string title, string contents)
        {
            var post = new Post(id, title, contents);
            
            post.RecordDomainEvent(new PostCreatedEvent
            {
                Contents = contents,
                PostId = id,
                Title = title
            });

            return post;
        }

        public void Update(string title, string contents)
        {
            Title = new PostTitle(title);
            Contents = new PostContents(contents);

            RecordDomainEvent(new PostUpdatedEvent
            {
                PostId = Id.Value,
                Title = title,
                Contents = contents
            });
        }
    }
}
