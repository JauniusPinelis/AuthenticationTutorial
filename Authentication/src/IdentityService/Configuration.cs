using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService
{
    public class Configuration
    {
        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>() {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
				{
                    Name = "rc.scope",
                    UserClaims = {"rc.grandma" }
				}
            };

        public static IEnumerable<ApiResource> GetApis() =>
            new List<ApiResource> {
                new ApiResource("ApiOne"),
                new ApiResource("ApiTwo")
            };

        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client_id",
                    ClientSecrets = { new Secret("client_secret".ToSha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"ApiOne"}
                },
                new Client
                {
                    ClientId = "client_id_mvc",
                    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44317/signin-oidc" },

                    AllowedScopes = {"ApiOne", "ApiTwo",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "rc.scope"
                    },

                    //AlwaysIncludeUserClaimsInIdToken = true;

                    RequireConsent = false,
                    AllowOfflineAccess = true
                },
                new Client
                {
                    ClientId = "client_id_js",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:44374/Home/signin" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "ApiOne",
                        "ApiTwo",
                        "rc.scope"
                    },

                    AccessTokenLifetime = 1,

                    AllowedCorsOrigins = { "https://localhost:44374" },
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false
                   
                    
                }
            };
    }
}
