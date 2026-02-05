using GeminiReference.Blog.API.Resources.v1.Posts.Shared.Routes;
using GeminiReference.Blog.Modules.Posts.Application.UseCases.DeletePost;
using GeminiReference.Blog.Modules.Posts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Neuraltech.SharedKernel.Infraestructure.Handlers;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.DeletePost
{
    public class DeletePostHandler : DeleteHandler<Post>
    {
        public DeletePostHandler(DeletePostUseCase useCase, ILogger<DeletePostHandler> logger)
            : base(useCase, logger) { }

        [HttpDelete(PostsRoutes.Delete)]
        public override ValueTask<IActionResult> Delete(string id)
        {
            return base.Delete(id);
        }
    }
}
