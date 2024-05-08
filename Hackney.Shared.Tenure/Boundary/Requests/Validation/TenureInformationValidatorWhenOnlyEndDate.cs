using FluentValidation;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class TenureInformationValidatorWhenOnlyEndDate : AbstractValidator<TenureInformation>
    {
        public TenureInformationValidatorWhenOnlyEndDate()
        {
            // tenureEndDate has been requested to be updated in the EditTenureDetails request.
            // The new end date must be validated against the start date that exists in the database

            // start date must exist
            RuleFor(x => x.StartOfTenureDate)
                .NotNull();

            // the end date must be greater than start date
            RuleFor(x => x.EndOfTenureDate)
            .GreaterThanOrEqualTo(x => x.StartOfTenureDate)
            .WithErrorCode(ErrorCodes.TenureEndDate);
        }
    }
}
