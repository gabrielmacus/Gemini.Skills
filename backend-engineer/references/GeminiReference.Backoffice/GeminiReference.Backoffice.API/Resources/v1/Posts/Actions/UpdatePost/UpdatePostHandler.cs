using GeminiReference.Backoffice.API.Resources.v1.Posts.Shared.Routes;
using GeminiReference.Backoffice.Modules.Posts.Application.UseCases.UpdatePost;
using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Neuraltech.SharedKernel.Infraestructure.Handlers;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.UpdatePost
{
    public class UpdatePostHandler : UpdateHandler<UpdatePostRequestDTO, UpdatePostDTO, Post>
    {
        public UpdatePostHandler(UpdatePostUseCase useCase)
            : base(useCase) { }

        [HttpPatch(PostsRoutes.Update)]
        public override ValueTask<IActionResult> Update(
            [FromRoute] string id,
            [FromBody] UpdatePostRequestDTO request
        )
        {
            return base.Update(id, request);
        }

        protected override UpdatePostDTO MapUseCaseRequest(UpdatePostRequestDTO request, Guid id)
        {
            return new UpdatePostDTO
            {
                Id = id,
                Title = request.Title,
                Contents = request.Contents,
            };
        }
    }
}
