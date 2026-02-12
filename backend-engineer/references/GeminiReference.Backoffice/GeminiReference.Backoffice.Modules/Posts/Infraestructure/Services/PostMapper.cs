using GeminiReference.Backoffice.Modules.Posts.Domain.Entities;
using GeminiReference.Backoffice.Modules.Posts.Infraestructure.Models;
using Neuraltech.SharedKernel.Infraestructure.Persistence.Contracts;

namespace GeminiReference.Backoffice.Modules.Posts.Infraestructure.Services
{
    public class PostMapper : IMapper<Post, PostModel>
    {
        public Post MapToEntity(PostModel model)
        {
            return new Post(model.Id, model.Title, model.Contents);
        }

        public PostModel MapToModel(Post entity)
        {
            return new PostModel
            {
                Id = entity.Id.Value,
                Title = entity.Title.Value,
                Contents = entity.Contents.Value,
            };
        }
    }
}
