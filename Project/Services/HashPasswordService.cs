using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Project.DTO;
using Project.DTO.InternalDTO;
using Project.Interfaces.IServices;
using Project.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Project.Services
{
    public class HashPasswordService : IHashPasswordService
    {
        public async Task<GeneralResponseInternalDTO> HashPassword(string password)
        {
            try
            {
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                var response = new GeneralResponseInternalDTO(true, hashed);
                return response;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }

        public async Task<GeneralResponseInternalDTO> VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                bool passwordMatch = hashed.Equals(hashedPassword);

                if (passwordMatch)
                {
                    return new GeneralResponseInternalDTO(true, "Password verified");
                }
                else
                {
                    return new GeneralResponseInternalDTO(false, "Invalid password");
                }
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
    }
}
