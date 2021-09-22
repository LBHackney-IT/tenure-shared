using FluentValidation;
using Hackney.Core.Validation;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class UpdateTenureRequestObjectValidation : AbstractValidator<UpdateTenureForPersonRequestObject>
    {
        public UpdateTenureRequestObjectValidation()
        {
            RuleFor(x => x.FullName).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
