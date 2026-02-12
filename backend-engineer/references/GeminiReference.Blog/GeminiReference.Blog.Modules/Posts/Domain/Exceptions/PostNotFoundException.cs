using Neuraltech.SharedKernel.Domain.Exceptions;

namespace GeminiReference.Blog.Modules.Posts.Domain.Exceptions
{
    public class PostNotFoundException : DomainException
    {
        private PostNotFoundException(string message)
            : base(message) { }

        public static PostNotFoundException FromId(Guid id)
        {
            return new PostNotFoundException($"Post with ID '{id}' was not found.");
        }
    }
}
