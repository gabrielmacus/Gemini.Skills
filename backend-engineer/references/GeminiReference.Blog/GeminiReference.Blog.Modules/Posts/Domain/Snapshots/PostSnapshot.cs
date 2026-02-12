namespace GeminiReference.Blog.Modules.Posts.Domain.Snapshots
{
    public record PostSnapshot
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
