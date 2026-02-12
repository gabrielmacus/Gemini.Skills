using Neuraltech.SharedKernel.Application.UseCases.Update;
using Neuraltech.SharedKernel.Domain.Base;

namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.UpdatePost
{
    public record UpdatePostDTO : UpdateDTO
    {
        public Optional<string> Title { get; init; }
        public Optional<string> Contents { get; init; }
    }
}
