using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class EditTenureInformationRequestValidatorTests
    {
        public EditTenureDetailsRequestValidation _classUnderTest;

        public EditTenureInformationRequestValidatorTests()
        {
            _classUnderTest = new EditTenureDetailsRequestValidation();
        }

        [Fact]
        public void WhenEndDateIsNullNoError()
        {
            var request = new EditTenureDetailsRequestObject()
            {
                StartOfTenureDate = DateTime.UtcNow,
                EndOfTenureDate = null
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void WhenStartDateIsNullNoError()
        {
            var request = new EditTenureDetailsRequestObject()
            {
                StartOfTenureDate = null,
                EndOfTenureDate = DateTime.UtcNow
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void WhenEndDateIsGreaterThanStartDateNoError()
        {
            var request = new EditTenureDetailsRequestObject()
            {
                StartOfTenureDate = DateTime.UtcNow,
                EndOfTenureDate = DateTime.UtcNow.AddDays(1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void WhenEndDateIsLessThanStartDateHasError()
        {
            var request = new EditTenureDetailsRequestObject()
            {
                StartOfTenureDate = DateTime.UtcNow,
                EndOfTenureDate = DateTime.UtcNow.AddDays(-1)
            };

            var result = _classUnderTest.TestValidate(request);

            result.ShouldHaveValidationErrorFor(x => x.EndOfTenureDate).WithErrorCode(ErrorCodes.TenureEndDate);
        }
    }
}
