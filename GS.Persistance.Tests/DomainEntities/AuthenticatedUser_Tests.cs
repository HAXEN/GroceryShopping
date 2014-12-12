using GS.TestTools.Mocks;
using GS.Web.Features.Authentication.Domain;

using Xunit;

namespace GS.Persistance.Tests.DomainEntities
{
    public class AuthenticatedUser_Tests : PersistanceTest
    {
        [Fact]
        public void Should_be_able_to_Save_AuthenticatedUser()
        {
            var authenticatedUser = AuthenticatedUser.Create(AuthenticatedClientMock.TestUser());

            using (var session = NewSession())
            {
                session.Store(authenticatedUser);
                session.SaveChanges();
            }

            using (var session = NewSession())
            {
                var loaded = session.Load<AuthenticatedUser>(authenticatedUser.Id);

                Assert.NotNull(loaded);
                Assert.Equal(authenticatedUser.Name, loaded.Name);
                Assert.Equal(authenticatedUser.PrimaryEmail(), loaded.PrimaryEmail());
            }
        }
    }
}
