using FluentValidation;
using System;
using Hackney.Shared.Tenure.Boundary.Requests;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class GetByIdRequestValidator : AbstractValidator<TenureQueryRequest>
    {
        public GetByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotNull()
                              .NotEqual(Guid.Empty);
        }
    }
}
