using GeminiReference.Blog.Modules.Posts.Domain.Snapshots;
using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Blog.Modules.Posts.Domain.Entities
{
    public class Post : AggregateRoot, IPrimitiveSerializable<Post, PostPrimitives>
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

        public PostPrimitives ToPrimitives() =>
            new()
            {
                Id = Id.Value,
                Title = Title.Value,
                Contents = Contents.Value,
            };

        public static Post FromPrimitives(PostPrimitives primitives) =>
            new(primitives.Id, primitives.Title, primitives.Contents);
    }
}
