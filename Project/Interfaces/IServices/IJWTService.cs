using Microsoft.IdentityModel.Tokens;
using Project.DTO.InternalDTO;

namespace Project.Interfaces.IServices
{
    public interface IJWTService
    {
        public Task<GeneralResponseInternalDTO> GenerateJwtToken(SymmetricSecurityKey securityKey, SigningCredentials credentials, string Email);
    }
}
