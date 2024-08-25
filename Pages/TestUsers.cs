// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace PD.IDP;

public static class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
            var address = new
            {
                street_address = "One Hacker Way",
                locality = "Heidelberg",
                postal_code = "69118",
                country = "Germany"
            };
                
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Pradip",
                    Password = "Pradip",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Pradipkumar Desai"),
                        new Claim(JwtClaimTypes.GivenName, "Pradipkumar"),
                        new Claim(JwtClaimTypes.FamilyName, "Desai"),
                        new Claim(JwtClaimTypes.Email, "PradipDesai@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Sunil",
                    Password = "Sunil",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Sunil Patil"),
                        new Claim(JwtClaimTypes.GivenName, "Sunil"),
                        new Claim(JwtClaimTypes.FamilyName, "Patil"),
                        new Claim(JwtClaimTypes.Email, "SunilPatil@email.com"),
                        new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                        new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                    }
                }
            };
        }
    }
}