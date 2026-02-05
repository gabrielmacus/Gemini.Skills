using System;
using System.Collections.Generic;
using System.Text;

namespace GeminiReference.Blog.Modules.Posts.Domain.Exceptions
{
    public class PostNotFoundException : Exception
    {
        private PostNotFoundException(string message)
            : base(message)
        {
        }

        public static PostNotFoundException FromId(Guid id)
        {
            return new PostNotFoundException($"Post with ID '{id}' was not found.");
        }
    }
}
