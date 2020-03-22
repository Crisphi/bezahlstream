
using System;
using System.Collections.Generic;
using BezahlStream.Backend.Database.Models.User;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;

public static class Config
{
    public static IEnumerable<ApiResource> Apis =>
        new List<ApiResource>
        {
            new ApiResource("api1", "My API")
        };

    public static IEnumerable<Client> Clients =>
    new List<Client>
    {
        new Client
        {
            ClientId = "client",
            AllowOfflineAccess = true,
            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            RedirectUris = { "http://localhost:5000/" },
            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "api1" }
        }
    };

    public static IEnumerable<IdentityResource> Ids => new List<IdentityResource>{
        new IdentityResources.Email()
    };

    public static IEnumerable<ApplicationUser> User
    {
        get
        {
            var user = new ApplicationUser()
            {
                UserName = "devel",
                NormalizedUserName = "DEVEL"
            };
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "12345");
            return new List<ApplicationUser>
            {
                user,
            };
        }
    }
}