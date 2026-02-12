namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.CreatePost
{
    public record CreatePostRequestDTO
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Contents { get; set; } = string.Empty;
    }
}
