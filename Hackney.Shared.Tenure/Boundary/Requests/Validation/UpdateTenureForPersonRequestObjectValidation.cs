using FluentValidation;
using Hackney.Core.Validation;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class UpdateTenureForPersonRequestObjectValidation : AbstractValidator<UpdateTenureForPersonRequestObject>
    {
        public UpdateTenureForPersonRequestObjectValidation()
        {
            RuleFor(x => x.FullName).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
