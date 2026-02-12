using GeminiReference.Backoffice.Modules.Posts.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Contexts;

namespace GeminiReference.Backoffice.Modules.SharedKernel.Infraestructure.Services
{
    public class BackofficeDbContext : BaseDbContext<BackofficeDbContext>
    {
        public DbSet<PostModel> Posts { get; set; }

        public BackofficeDbContext(DbContextOptions<BackofficeDbContext> options)
            : base(options) { }
    }
}
