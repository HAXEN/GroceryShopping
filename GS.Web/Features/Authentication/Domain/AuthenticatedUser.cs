using System;
using System.Collections.Generic;
using System.Linq;

using GS.Domain;

using Newtonsoft.Json;

using SimpleAuthentication.Core;

namespace GS.Web.Features.Authentication.Domain
{
    public class AuthenticatedUser : GuidAggregateRoot<AuthenticatedUser>
    {
        public string Name { get; protected set; }
        [JsonProperty]protected IEnumerable<UserEmail> UserEmails { get; set; }

        public AuthenticatedUser()
        {
            UserEmails = new UserEmail[0];
        }

        public Email PrimaryEmail()
        {
            var primaryEmail = UserEmails.FirstOrDefault(x => x.Primary);

            if (primaryEmail == null)
                return null;

            return primaryEmail.Email;
        }

        public void Add(Email email)
        {
            var userEmails = new HashSet<UserEmail>(UserEmails);

            userEmails.Add(UserEmail.Create(email, !userEmails.Any()));

            UserEmails = userEmails;
        }

        public static AuthenticatedUser Create(IAuthenticatedClient authenticatedClient)
        {
            var authenticatedUser = new AuthenticatedUser
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    Name = authenticatedClient.UserInformation.Name,
                };

            authenticatedUser.Add(Email.Parse(authenticatedClient.UserInformation.Email));

            return authenticatedUser;
        }

        public class UserEmail
        {
            public Email Email { get; protected set; }
            public bool Primary { get; protected set; }
            public DateTime? VerifiedAt { get; protected set; }

            public static UserEmail Create(Email email, bool primary)
            {
                return new UserEmail
                    {
                        Email = email,
                        Primary = primary,
                    };
            }
        }
    }
}