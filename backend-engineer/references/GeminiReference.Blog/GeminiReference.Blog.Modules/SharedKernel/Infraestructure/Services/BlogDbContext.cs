using GeminiReference.Blog.Modules.Posts.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Contexts;


namespace GeminiReference.Blog.Modules.SharedKernel.Infraestructure.Services
{
    public class BlogDbContext : BaseDbContext<BlogDbContext>
    {
        public DbSet<PostModel> Posts { get; set; }

        public BlogDbContext(
            DbContextOptions<BlogDbContext> options
        ) : base(options)
        {
        }
    }
}
