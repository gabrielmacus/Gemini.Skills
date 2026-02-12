using GeminiReference.Backoffice.API.Resources.v1.Posts.Shared.Routes;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.DeletePost;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Neuraltech.SharedKernel.Infraestructure.Handlers;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.DeletePost
{
    public class DeletePostHandler : DeleteHandler<Post>
    {
        public DeletePostHandler(DeletePostUseCase useCase, ILogger<DeletePostHandler> logger)
            : base(useCase, logger) { }

        [HttpDelete(PostsRoutes.Delete)]
        public override ValueTask<IActionResult> Delete([FromRoute] string id)
        {
            return base.Delete(id);
        }
    }
}
