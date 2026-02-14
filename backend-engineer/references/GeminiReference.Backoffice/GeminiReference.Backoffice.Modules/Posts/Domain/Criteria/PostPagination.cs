using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Domain.Base.Criteria;

namespace GeminiReference.Backoffice.Modules.Posts.Domain.Criteria
{
    public record PostPagination : Pagination
    {
        public const long MaxPage = 20;
        public const long MaxSize = 100;

        public static long MaxPageLimit => 20;
        public static long MaxSizeLimit => 100;

        protected override long MaxPageAllowed => MaxPageLimit;
        protected override long MaxSizeAllowed => MaxSizeLimit;

        public PostPagination(Optional<long> size, Optional<long> page)
            : base(size, page) { }
    }
}
