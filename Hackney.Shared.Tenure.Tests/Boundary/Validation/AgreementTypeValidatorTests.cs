using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class AgreementTypeValidatorTests
    {
        public AgreementTypeValidator _classUnderTest;

        public AgreementTypeValidatorTests()
        {
            _classUnderTest = new AgreementTypeValidator();
        }
        private const string StringWithTags = "Some string with <tag> in it.";



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CodeShouldNotErrorWithNoValue(string value)
        {
            var model = new AgreementType() { Code = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Code);

        }

        [Fact]
        public void CodeShouldErrorWithhTagsInValue()
        {
            var model = new AgreementType() { Code = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Code)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DescriptionShouldNotErrorWithNoValue(string value)
        {
            var model = new AgreementType() { Description = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Description);

        }

        [Fact]
        public void DescriptionShouldErrorWithhTagsInValue()
        {
            var model = new AgreementType() { Description = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
