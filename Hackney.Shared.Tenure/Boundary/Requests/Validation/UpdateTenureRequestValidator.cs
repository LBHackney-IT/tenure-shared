using FluentValidation;
using System;
using Hackney.Shared.Tenure.Boundary.Requests;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class UpdateTenureRequestValidator : AbstractValidator<UpdateTenureRequest>
    {
        public UpdateTenureRequestValidator()
        {
            RuleFor(x => x.Id).NotNull()
                              .NotEqual(Guid.Empty);
            RuleFor(x => x.PersonId).NotNull()
                              .NotEqual(Guid.Empty);
        }
    }
}
