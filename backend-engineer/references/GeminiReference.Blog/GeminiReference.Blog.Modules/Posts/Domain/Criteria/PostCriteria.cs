using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Domain.Base.Criteria;
using Neuraltech.SharedKernel.Domain.Base.Criteria.Filtering;

namespace GeminiReference.Blog.Modules.Posts.Domain.Criteria
{
    public class PostCriteria : BaseCriteria<PostCriteria>
    {
        public PostCriteria WithTitle(Optional<string> title)
        {
            if (title.HasValue)
                return AddFilter("Title", FilterOperators.EQ, title.Value);
            return this;
        }

        public PostCriteria WithContentsContaining(Optional<string> keyword)
        {
            if (keyword.HasValue)
                return AddFilter("Contents", FilterOperators.CONTAINS, keyword.Value);
            return this;
        }
    }
}
