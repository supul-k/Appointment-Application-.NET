using Microsoft.IdentityModel.Tokens;
using Project.DTO.InternalDTO;
using Project.Interfaces.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Project.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;
        public JWTService(IConfiguration configuration) 
        {
            _config = configuration;
        }

        public async Task<GeneralResponseInternalDTO> GenerateJwtToken(SymmetricSecurityKey securityKey, SigningCredentials credentials, string Email)
        {
            try
            {
                var token = new JwtSecurityToken(
                        issuer: _config["Jwt:Issuer"], 
                        audience: null,
                        expires: DateTime.Now.AddMinutes(240),
                        signingCredentials: credentials,
                        claims: new[]
                        {
                            new Claim("Email", Email)
                        }
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                var response = new GeneralResponseInternalDTO(true, tokenString, "Token Created Successfully");
                return response;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
    }
}
