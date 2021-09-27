using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Tenure.Domain;
using System;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    // For validating Tenure Information when attached to a person
    public class TenureInformationValidator : AbstractValidator<TenureInformation>
    {
        public TenureInformationValidator()
        {
            RuleFor(x => x.TenuredAsset).SetValidator(new TenuredAssetValidator());
            RuleFor(x => x.StartOfTenureDate)
                    .LessThan(x => x.EndOfTenureDate)
                    .WithErrorCode(ErrorCodes.TenureEndDate)
                    .When(y => y.EndOfTenureDate.HasValue);
            RuleFor(x => x.EndOfTenureDate)
                .GreaterThan(x => x.StartOfTenureDate)
                .WithErrorCode(ErrorCodes.TenureEndDate)
                .When(y => y.StartOfTenureDate.HasValue);
            RuleFor(x => x.Id).NotNull()
                .NotEqual(Guid.Empty);
            RuleFor(x => x.TenureType).SetValidator(new TenureTypeValidator());
            RuleFor(x => x.PaymentReference)
                .NotXssString()
                .WithErrorCode(ErrorCodes.XssCheckFailure)
                .When(y => !string.IsNullOrEmpty(y.TenuredAsset.Uprn));
        }
    }
}
