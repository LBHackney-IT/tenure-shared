using FluentValidation;
using Hackney.Core.Validation;
using System;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class AgreementTypeValidator : AbstractValidator<AgreementType>
    {
        public AgreementTypeValidator()
        {
            RuleFor(x => x.Description).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleFor(x => x.Code).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
