using System.Security.Claims;

namespace Neuronix.Api.Validations;

public static class AuthorizationValidator
{
    public static int GetIdUser(List<Claim> claims)
    {
        var claimsUser = claims.ToList();
        var userId = claimsUser?.FirstOrDefault(x => x.Type.Equals("NameUid", StringComparison.OrdinalIgnoreCase))?.Value;
        if (userId != null) return Int32.Parse(userId);
        return 0;
    }
}