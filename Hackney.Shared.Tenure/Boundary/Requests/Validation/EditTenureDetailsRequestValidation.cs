using FluentValidation;
using Hackney.Core.Validation;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class EditTenureDetailsRequestValidation : AbstractValidator<EditTenureDetailsRequestObject>
    {
        public EditTenureDetailsRequestValidation()
        {
            // both values must be in request
            // otherwise, validation is called in the gateway method.
            When(tenure => tenure.EndOfTenureDate != null && tenure.StartOfTenureDate != null, () =>
            {
                RuleFor(x => x.EndOfTenureDate)
               .GreaterThan(x => x.StartOfTenureDate)
               .WithErrorCode(ErrorCodes.TenureEndDate);
            });

            RuleFor(x => x.TenureType).SetValidator(new TenureTypeValidator());
        }
    }
}
