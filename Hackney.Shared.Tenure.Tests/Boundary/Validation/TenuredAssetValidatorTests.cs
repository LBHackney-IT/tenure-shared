using FluentValidation.TestHelper;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class TenuredAssetValidatorTests
    {
        public TenuredAssetValidator _classUnderTest;

        public TenuredAssetValidatorTests()
        {
            _classUnderTest = new TenuredAssetValidator();
        }
        private const string StringWithTags = "Some string with <tag> in it.";



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FullAddressShouldNotErrorWithNoValue(string value)
        {
            var model = new TenuredAsset() { FullAddress = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.FullAddress);

        }

        [Fact]
        public void FullAddressShouldErrorWithTagsInValue()
        {
            var model = new TenuredAsset() { FullAddress = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.FullAddress)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void UprnShouldNotErrorWithNoValue(string value)
        {
            var model = new TenuredAsset() { Uprn = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Uprn);

        }

        [Fact]
        public void UprnShouldErrorWithTagsInValue()
        {
            var model = new TenuredAsset() { Uprn = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Uprn)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }

        [Theory]
        [InlineData("dflkgjdflgj")]
        [InlineData("00")]
        [InlineData("00000")]
        public void PropertyReferenceShouldErrorWithInvalidValueInValue(string value)
        {
            var model = new TenuredAsset() { PropertyReference = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PropertyReference);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("098452")]
        [InlineData("9874328")]
        [InlineData("9874328456778")]
        public void PropertyReferenceShouldNotErrorWithValidValue(string value)
        {
            var model = new TenuredAsset() { PropertyReference = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.PropertyReference);

        }

        [Fact]
        public void PropertyReferenceShouldErrorWithTagsInValue()
        {
            var model = new TenuredAsset() { PropertyReference = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PropertyReference)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
