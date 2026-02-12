using FluentValidation;
using GeminiReference.Backoffice.API.Resources.v1.Posts.Shared.Localization;
using GeminiReference.Backoffice.Modules.Posts.Domain.ValueObjects;
using Microsoft.Extensions.Localization;
using Neuraltech.SharedKernel.Infraestructure.Validation;

namespace GeminiReference.Backoffice.API.Resources.v1.Posts.Actions.CreatePost
{
    public class CreatePostValidator : AbstractValidator<CreatePostRequestDTO>
    {
        public CreatePostValidator(IStringLocalizer<PostsLocalization> localizer)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(localizer["Validation_Id_Required"])
                .Must(ValidationExtensions.BeAValidGuid)
                .WithMessage(localizer["Validation_Id_InvalidGuid"]);

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(localizer["Validation_Title_Required"])
                .MinimumLength(PostTitle.MIN_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Title_TooShort", PostTitle.MIN_LENGTH)
                )
                .MaximumLength(PostTitle.MAX_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Title_TooLong", PostTitle.MAX_LENGTH)
                );

            RuleFor(x => x.Contents)
                .NotEmpty()
                .WithMessage(localizer["Validation_Contents_Required"])
                .MinimumLength(PostContents.MIN_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Contents_TooShort", PostContents.MIN_LENGTH)
                )
                .MaximumLength(PostContents.MAX_LENGTH)
                .WithMessage(x =>
                    localizer.GetString("Validation_Contents_TooLong", PostContents.MAX_LENGTH)
                );
        }
    }
}
