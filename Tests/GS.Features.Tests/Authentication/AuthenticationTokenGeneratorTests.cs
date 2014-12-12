using GS.TestTools.Mocks;
using GS.Web.Features.Authentication.Domain;

using Xunit;

namespace GS.Features.Tests.Authentication
{
    public class AuthenticationTokenGeneratorTests
    {
        private AuthenticatedUser _user;
        private AuthenticationTokenGenerator _generator;

        public AuthenticationTokenGeneratorTests()
        {
            _user = AuthenticatedUser.Create(AuthenticatedClientMock.TestUser());
            _generator = new AuthenticationTokenGenerator();
        }

        [Fact]
        public void Should_be_able_to_Create_AuthenticationToken()
        {
            var token = _generator.CreateToken(_user);

            Assert.NotNull(token);
        }
    }

    public class AuthenticationTokenGenerator
    {
        public object CreateToken(AuthenticatedUser authenticatedUser)
        {
            return null;
        }
    }
}
