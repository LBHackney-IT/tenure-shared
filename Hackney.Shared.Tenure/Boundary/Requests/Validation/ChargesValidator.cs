using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class ChargesValidator : AbstractValidator<Charges>
    {
        public ChargesValidator()
        {
            RuleFor(x => x.BillingFrequency).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
