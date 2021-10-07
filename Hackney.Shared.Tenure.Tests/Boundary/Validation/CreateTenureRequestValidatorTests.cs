using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using System;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class CreateTenureRequestValidatorTests
    {
        public CreateTenureRequestValidation _classUnderTest;

        public CreateTenureRequestValidatorTests()
        {
            _classUnderTest = new CreateTenureRequestValidation();
        }
        private const string StringWithTags = "Some string with <tag> in it.";

        [Fact]
        public void WhenEndDateisCorrectNoError()
        {
            var request = new CreateTenureRequestObject()
            {
                EndOfTenureDate = DateTime.UtcNow.AddDays(1),
                StartOfTenureDate = DateTime.UtcNow
            };
            var result = _classUnderTest.TestValidate(request);
            result.ShouldNotHaveValidationErrorFor(x => x.EndOfTenureDate);
        }

        [Fact]
        public void WhenEndDateIsInCorrectHasError()
        {
            var request = new CreateTenureRequestObject()
            {
                EndOfTenureDate = DateTime.UtcNow,
                StartOfTenureDate = DateTime.UtcNow.AddDays(1)
            };
            var result = _classUnderTest.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.EndOfTenureDate)
                .WithErrorCode(ErrorCodes.TenureEndDate);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void PaymentReferenceShouldNotErrorWithNoValue(string value)
        {
            var model = new CreateTenureRequestObject() { PaymentReference = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.PaymentReference);

        }

        [Fact]
        public void PaymentReferenceShouldErrorWithhTagsInValue()
        {
            var model = new CreateTenureRequestObject() { PaymentReference = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PaymentReference)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
