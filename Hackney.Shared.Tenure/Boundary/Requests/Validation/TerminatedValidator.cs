using FluentValidation;
using Hackney.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class TerminatedValidator : AbstractValidator<Terminated>
    {
        public TerminatedValidator()
        {
            RuleFor(x => x.ReasonForTermination).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
