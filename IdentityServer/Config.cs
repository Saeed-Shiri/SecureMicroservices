using Duende.IdentityServer.Models;
using Duende.IdentityServer.Test;

namespace IdentityServer;
public class Config
{
    public static IEnumerable<Client> Clients => [];

    public static IEnumerable<ApiScope> ApiScopes => [];

    public static IEnumerable<ApiResource> ApiResources => [];

    public static IEnumerable<IdentityResource> IdentityResources => [];

    public static IEnumerable<TestUser> TestUsers => [];

}

