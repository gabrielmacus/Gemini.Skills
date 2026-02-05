using FluentValidation;
using GeminiReference.Blog.API.Localization;
using GeminiReference.Blog.Modules.Posts.Domain.ValueObjects;
using Microsoft.Extensions.Localization;
using Neuraltech.SharedKernel.Infraestructure.Validation;

namespace GeminiReference.Blog.API.Resources.v1.Posts.Actions.CreatePost
{
    public class CreatePostValidator : AbstractValidator<CreatePostRequestDTO>
    {
        public CreatePostValidator(IStringLocalizer<SharedResource> localizer)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                    .WithMessage(localizer["Validation_FieldShouldNotBeEmpty"])
                .Must(ValidationExtensions.BeAValidGuid)
                    .WithMessage(localizer["Validation_InvalidGuid"]);

            RuleFor(x => x.Title)
                .NotEmpty()
                    .WithMessage(localizer["Validation_FieldShouldNotBeEmpty"])
                .MinimumLength(PostTitle.MIN_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooShort", PostTitle.MIN_LENGTH)
                    )
                .MaximumLength(PostTitle.MAX_LENGTH)
                    .WithMessage(x =>
                            localizer.GetString("Validation_FieldTooLong", PostTitle.MAX_LENGTH)
                    );

            RuleFor(x => x.Contents)
                .NotEmpty()
                    .WithMessage(localizer["Validation_FieldShouldNotBeEmpty"])
                .MinimumLength(PostContents.MIN_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooShort", PostContents.MIN_LENGTH)
                    )
                .MaximumLength(PostContents.MAX_LENGTH)
                    .WithMessage(x =>
                        localizer.GetString("Validation_FieldTooLong", PostContents.MAX_LENGTH)
                    );
        }
    }
}
