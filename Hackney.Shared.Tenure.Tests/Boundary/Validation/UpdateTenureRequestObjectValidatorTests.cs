using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class UpdateTenureRequestObjectValidatorTests
    {
        private const string StringWithTags = "Some string with <tag> in it.";

        public UpdateTenureRequestObjectValidation _classUnderTest;
        public UpdateTenureRequestObjectValidatorTests()
        {
            _classUnderTest = new UpdateTenureRequestObjectValidation();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RequesthouldNotErrorWithNoValue(string value)
        {
            var model = new UpdateTenureForPersonRequestObject() { FullName = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.FullName);

        }

        [Fact]
        public void RequestShouldErrorWithTagsInValue()
        {
            var model = new UpdateTenureForPersonRequestObject() { FullName = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullName)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
