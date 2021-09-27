using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class LegacyReferenceValidator : AbstractValidator<LegacyReference>
    {
        public LegacyReferenceValidator()
        {
            RuleFor(x => x.Name).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleFor(x => x.Value).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
