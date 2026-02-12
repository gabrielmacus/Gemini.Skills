using System.ComponentModel.DataAnnotations;
using GeminiReference.Backoffice.Modules.Posts.Domain.ValueObjects;
using Neuraltech.SharedKernel.Infraestructure.Persistence.EFCore.Models;

namespace GeminiReference.Backoffice.Modules.Posts.Infraestructure.Models
{
    public class PostModel : BaseEFCoreModel
    {
        [Required]
        [MaxLength(PostTitle.MAX_LENGTH)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(PostContents.MAX_LENGTH)]
        public required string Contents { get; set; }
    }
}
