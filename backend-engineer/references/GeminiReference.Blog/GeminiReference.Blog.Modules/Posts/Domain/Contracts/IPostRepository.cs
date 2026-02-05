using GeminiReference.Blog.Modules.Posts.Domain.Criteria;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Blog.Modules.Posts.Domain.Contracts
{
    public interface IPostRepository : IRepository<Post, PostCriteria>
    {
    }
}
