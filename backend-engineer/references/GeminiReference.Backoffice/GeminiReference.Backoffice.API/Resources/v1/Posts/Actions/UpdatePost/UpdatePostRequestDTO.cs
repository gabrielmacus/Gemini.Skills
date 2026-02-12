using System.Text.Json.Serialization;
using Neuraltech.SharedKernel.Domain.Base;
using Neuraltech.SharedKernel.Infraestructure.Services;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.UpdatePost
{
    public record UpdatePostRequestDTO
    {
        [JsonConverter(typeof(OptionalConverter<string>))]
        public Optional<string> Title { get; init; }

        [JsonConverter(typeof(OptionalConverter<string>))]
        public Optional<string> Contents { get; init; }
    }
}
