using Fixxo_Web_Api.Contexts;
using Fixxo_Web_Api.Models.Entities;
using NuGet.Protocol.Core.Types;

namespace Fixxo_Web_Api.Repositories;

public class UserProfileRepository : Repository<UserProfileEntity>
{
    private readonly IdentityContext _identityContext;
    
    public UserProfileRepository(IdentityContext identityContext) : base(identityContext)
    {
        _identityContext = identityContext;
    }
}