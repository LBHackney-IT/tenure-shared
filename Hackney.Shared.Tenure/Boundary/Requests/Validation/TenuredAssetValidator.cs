using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class TenuredAssetValidator : AbstractValidator<TenuredAsset>
    {
        public TenuredAssetValidator()
        {
            long longVal;
            RuleFor(x => x.PropertyReference).MinimumLength(6)
                                             .Must(x => long.TryParse(x, out longVal))
                                             .When(x => !string.IsNullOrEmpty(x.PropertyReference));

            RuleFor(x => x.FullAddress).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleFor(x => x.Uprn).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleFor(x => x.PropertyReference).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

    }
}
