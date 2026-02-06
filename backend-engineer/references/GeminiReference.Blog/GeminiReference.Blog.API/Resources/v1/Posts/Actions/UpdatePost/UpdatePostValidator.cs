using FluentValidation;
using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Microsoft.Extensions.Localization;
using Neuraltech.SharedKernel.Infraestructure.Localization;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.UpdatePost
{
    public class UpdatePostValidator : AbstractValidator<UpdatePostRequestDTO>
    {
        public UpdatePostValidator(IStringLocalizer<SharedLocalization> localizer)
        {
            RuleFor(x => x.Title.Value)
                .NotEmpty()
                    .WithMessage(localizer["Validation_FieldShouldNotBeEmpty"])
                .MinimumLength(PostTitle.MIN_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooShort", PostTitle.MIN_LENGTH)
                    )
                .MaximumLength(PostTitle.MAX_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooLong", PostTitle.MAX_LENGTH)
                    )
                .When(x => x.Title.HasValue);

            RuleFor(x => x.Contents.Value)
                .NotEmpty()
                    .WithMessage(localizer["Validation_FieldShouldNotBeEmpty"])
                .MinimumLength(PostContents.MIN_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooShort", PostContents.MIN_LENGTH)
                    )
                .MaximumLength(PostContents.MAX_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooLong", PostContents.MAX_LENGTH)
                    )
                .When(x => x.Contents.HasValue);
        }
    }
}
