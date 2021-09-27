using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class TenureInformationValidatorWhenOnlyStartDateTests
    {
        public TenureInformationValidatorWhenOnlyStartDate _classUnderTest;

        public TenureInformationValidatorWhenOnlyStartDateTests()
        {
            _classUnderTest = new TenureInformationValidatorWhenOnlyStartDate();
        }

        [Fact]
        public void WhenEndDateIsNullNoError()
        {
            var request = new TenureInformation()
            {
                StartOfTenureDate = DateTime.UtcNow,
                EndOfTenureDate = null
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.EndOfTenureDate);
        }

        [Fact]
        public void WhenEndDateIsGreaterThanStartDateNoError()
        {
            var request = new TenureInformation()
            {
                StartOfTenureDate = DateTime.UtcNow,
                EndOfTenureDate = DateTime.UtcNow.AddDays(1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.EndOfTenureDate);
        }

        [Fact]
        public void WhenEndDateIsLessThanStartDateHasError()
        {
            var request = new TenureInformation()
            {
                StartOfTenureDate = DateTime.UtcNow,
                EndOfTenureDate = DateTime.UtcNow.AddDays(-1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.StartOfTenureDate).WithErrorCode(ErrorCodes.TenureEndDate);
        }
    }
}
