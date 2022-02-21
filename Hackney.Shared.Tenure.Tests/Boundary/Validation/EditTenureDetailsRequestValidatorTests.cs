using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using System;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class EditTenureDetailsRequestValidatorTests
    {
        public EditTenureDetailsRequestValidation _classUnderTest;
        private const string StringWithTags = "Some string with <tag> in it.";

        public EditTenureDetailsRequestValidatorTests()
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void PaymentReferenceShouldNotErrorWithNoValue(string value)
        {
            var model = new EditTenureDetailsRequestObject()
            {
                PaymentReference = value 
            };

            var result = _classUnderTest.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.PaymentReference);

        }

        [Fact]
        public void PaymentReferenceShouldErrorWithhTagsInValue()
        {
            var model = new EditTenureDetailsRequestObject()
            {
                PaymentReference = StringWithTags
            };

            var result = _classUnderTest.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.PaymentReference)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
