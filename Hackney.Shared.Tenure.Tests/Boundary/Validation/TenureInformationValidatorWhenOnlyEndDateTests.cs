using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using System;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class TenureInformationValidatorWhenOnlyEndDateTests
    {
        public TenureInformationValidatorWhenOnlyEndDate _classUnderTest;

        public TenureInformationValidatorWhenOnlyEndDateTests()
        {
            _classUnderTest = new TenureInformationValidatorWhenOnlyEndDate();
        }


        [Fact]
        public void WhenStartDateIsNullhasError()
        {
            var request = new TenureInformation()
            {
                StartOfTenureDate = null,
                EndOfTenureDate = DateTime.UtcNow.AddDays(1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.StartOfTenureDate);
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

            result.ShouldHaveValidationErrorFor(x => x.EndOfTenureDate).WithErrorCode(ErrorCodes.TenureEndDate);
        }
    }
}
