using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hackney.Shared.Tenure.Boundary.Requests.Validation;
using Hackney.Shared.Tenure.Domain;
using Xunit;

namespace Hackney.Shared.Tenure.Tests.Boundary.Validation
{
    public class TerminatedValidatorTests
    {
        public TerminatedValidator _classUnderTest;

        public TerminatedValidatorTests()
        {
            _classUnderTest = new TerminatedValidator();
        }
        private const string StringWithTags = "Some string with <tag> in it.";



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ReasonForTerminationShouldNotErrorWithNoValue(string value)
        {
            var model = new Terminated() { ReasonForTermination = value };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.ReasonForTermination);

        }

        [Fact]
        public void ReasonForTerminationShouldErrorWithhTagsInValue()
        {
            var model = new Terminated() { ReasonForTermination = StringWithTags };
            var result = _classUnderTest.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.ReasonForTermination)
                .WithErrorCode(ErrorCodes.XssCheckFailure);
        }


    }
}
