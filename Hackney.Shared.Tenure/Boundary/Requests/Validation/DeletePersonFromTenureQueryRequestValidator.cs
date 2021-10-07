using FluentValidation;
using System;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class DeletePersonFromTenureQueryRequestValidator : AbstractValidator<DeletePersonFromTenureQueryRequest>
    {
        public DeletePersonFromTenureQueryRequestValidator()
        {
            RuleFor(x => x.TenureId).NotNull()
                              .NotEqual(Guid.Empty);
            RuleFor(x => x.PersonId).NotNull()
                              .NotEqual(Guid.Empty);
        }
    }
}
