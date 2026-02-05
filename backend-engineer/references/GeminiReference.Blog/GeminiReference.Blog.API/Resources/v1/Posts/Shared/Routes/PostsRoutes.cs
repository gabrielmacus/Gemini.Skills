namespace GeminiReference.Blog.API.Resources.v1.Posts.Shared.Routes
{
    public static class PostsRoutes
    {
        public const string Base = "posts";

        public const string Create = Base;
        public const string Get = Base + "/{id:guid}";
        public const string Update = Base + "/{id:guid}";
        public const string Delete = Base + "/{id:guid}";
        public const string Paginate = Base;
    }
}
