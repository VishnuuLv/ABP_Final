using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("myresourceapi","My Resource Api")
                {
                   Scopes = {new Scope("apiscope")}
                }
            };
        }
        
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId="secret_client_id",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                    ,
                    AllowedScopes={"apiscope"}
                },
                new Client
                {
                    ClientId="user_client_id",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                    ,
                    AllowedScopes={"apiscope"}
                }
            };
        }
    }
}
