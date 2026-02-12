namespace GeminiReference.Backoffice.Modules.Posts.Application.UseCases.CreatePost
{
    public record CreatePostDTO
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
