namespace GeminiReference.Backoffice.Modules.Posts.Domain.Primitives
{
    public record PostPrimitives
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
