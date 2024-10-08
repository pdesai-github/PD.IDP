﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace PD.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            {
                new ApiScope("TestApi.FullAccess")
            };

    public static IEnumerable<ApiResource> ApiResources =>
        new ApiResource[]
            {
                new ApiResource("TestApi", "Test API")
                {
                    Scopes = { "TestApi.FullAccess" }
                }
            };

    public static IEnumerable<Client> Clients =>
        new Client[]
            {
                new Client()
                {
                    ClientName = "Test client",
                    ClientId ="TEST_CLIENT_ID",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris={ "https://localhost:7261/signin-oidc" },
                    PostLogoutRedirectUris={"https://localhost:7261/signout-callback-oidc" },
                    AllowedScopes=
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "TestApi.FullAccess"
                    },
                    ClientSecrets=
                    {
                        new Secret("TestClientSecret".Sha256())
                    },
                    RequireConsent = true
                }
            };
}