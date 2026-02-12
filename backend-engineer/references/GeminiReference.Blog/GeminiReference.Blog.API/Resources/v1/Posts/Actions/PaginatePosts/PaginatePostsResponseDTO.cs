namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.PaginatePosts
{
    public record PaginatePostsResponseDTO 
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required string Contents { get; init; }
    }
}
