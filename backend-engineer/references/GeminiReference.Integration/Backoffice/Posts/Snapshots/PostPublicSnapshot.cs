namespace GeminiReference.Integration.Backoffice.Posts.Snapshots
{
    public record PostPublicSnapshot
    {
        public static readonly string PublicMessageName =
            "GeminiReference.Backoffice.Posts.PostSnapshot";
        public string MessageName => PublicMessageName;

        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
