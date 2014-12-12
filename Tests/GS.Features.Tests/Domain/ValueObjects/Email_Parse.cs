using GS.Domain;

using Xunit;

namespace GS.Features.Tests.Domain.ValueObjects
{
    public class Email_Parse
    {
        [Fact]
        public void Should_return_null_when_not_valid_Value()
        {
            Assert.Null(Email.Parse(""));
        }

        [Fact]
        public void Should_return_instance_when_valid_Value()
        {
            Assert.NotNull(Email.Parse("test.user@mail.com"));
        }
    }
}