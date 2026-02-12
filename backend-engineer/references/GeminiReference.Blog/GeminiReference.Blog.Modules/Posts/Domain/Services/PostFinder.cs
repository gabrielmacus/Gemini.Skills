using GeminiReference.Blog.Modules.Posts.Domain.Contracts;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using GeminiReference.Blog.Modules.Posts.Domain.Exceptions;

namespace GeminiReference.Blog.Modules.Posts.Domain.Services
{
    public class PostFinder
    {
        private readonly IPostRepository _repository;

        public PostFinder(IPostRepository repository)
        {
            _repository = repository;
        }

        public async ValueTask<Post> FindOrFail(Guid id)
        {
            var post = await _repository.Find(id);
            if (post == null)
            {
                throw PostNotFoundException.FromId(id);
            }
            return post;
        }
    }
}
