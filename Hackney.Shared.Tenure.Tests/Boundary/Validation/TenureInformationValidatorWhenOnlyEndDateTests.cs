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

        DateTime _aSetDate = new DateTime(2024, 5, 7);

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
                EndOfTenureDate = _aSetDate.AddDays(1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.StartOfTenureDate);
        }

        [Fact]
        public void WhenEndDateIsGreaterThanStartDateNoError()
        {
            var request = new TenureInformation()
            {
                StartOfTenureDate = _aSetDate,
                EndOfTenureDate = _aSetDate.AddDays(1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.EndOfTenureDate);
        }

        [Fact]
        public void WhenEndDateIsEqualToStartDateNoError()
        {

            var request = new TenureInformation()
            {
                StartOfTenureDate = _aSetDate,
                EndOfTenureDate = _aSetDate
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(x => x.EndOfTenureDate);
        }

        [Fact]
        public void WhenEndDateIsLessThanStartDateHasError()
        {
            var request = new TenureInformation()
            {
                StartOfTenureDate = _aSetDate,
                EndOfTenureDate = _aSetDate.AddDays(-1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.EndOfTenureDate).WithErrorCode(ErrorCodes.TenureEndDate);
        }
    }
}
