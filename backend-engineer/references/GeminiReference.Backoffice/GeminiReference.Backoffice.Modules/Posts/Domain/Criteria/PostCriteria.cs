using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Domain.Base.Criteria;
using Neuraltech.SharedKernel.Domain.Base.Criteria.Filtering;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Criteria
{
    public class PostCriteria : BaseCriteria<PostCriteria>
    {
        public PostCriteria WithTitle(Optional<string> title)
        {
            if (!title.HasValue) return this;
            return AddFilter("Title", FilterOperators.EQ, title.Value);
        }

        public PostCriteria WithContentsContaining(Optional<string> keyword)
        {
            if (!keyword.HasValue) return this;
            return AddFilter("Contents", FilterOperators.CONTAINS, keyword.Value);
        }
    }
}
