using FluentValidation;
using Hackney.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackney.Shared.Tenure.Domain;

namespace Hackney.Shared.Tenure.Boundary.Requests.Validation
{
    public class TenuredAssetValidator : AbstractValidator<TenuredAsset>
    {
        public TenuredAssetValidator()
        {
            RuleFor(x => x.FullAddress).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleFor(x => x.Uprn).NotXssString()
                         .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

    }
}
