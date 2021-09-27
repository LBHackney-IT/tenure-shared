using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class HouseholdMemberValidator : AbstractValidator<HouseholdMembers>
    {
        public HouseholdMemberValidator()
        {
            RuleFor(x => x.FullName).NotXssString()
                                     .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
