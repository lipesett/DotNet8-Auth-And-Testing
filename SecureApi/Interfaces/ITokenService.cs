using SecureApi.Models;

namespace SecureApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}