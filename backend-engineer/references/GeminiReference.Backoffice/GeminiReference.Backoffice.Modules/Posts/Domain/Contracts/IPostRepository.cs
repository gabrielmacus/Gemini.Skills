using GeminiReference.Backoffice.Modules.Posts.Domain.Criteria;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Neuraltech.SharedKernel.Domain.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Contracts
{
    public interface IPostRepository : IRepository<Post, PostCriteria> { }
}
