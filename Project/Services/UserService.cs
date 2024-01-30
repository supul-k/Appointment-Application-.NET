using Microsoft.EntityFrameworkCore;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Interfaces.IServices;
using Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPasswordService _hashPasswordService;

        public UserService(IUserRepository userRepository, IHashPasswordService hashPasswordService)
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
        }
        public async Task<GeneralResponseInternalDTO> AddUser(UserModel user)
        {
            try
            {
                var result= await _userRepository.AddUser(user);
                return result;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }

        public async Task<GeneralResponseInternalDTO> UserExist(string Email)
        {
            try
            {
                var result = await _userRepository.UserExist(Email);
                return result;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }

        public async Task<GeneralResponseInternalDTO> AuthenticateUser(string password, string hashedPassword)
        {
            try
            {
                var passwordVerificationResult = await _hashPasswordService.VerifyPassword(password, hashedPassword);

                if (!passwordVerificationResult.Status)
                {
                    return new GeneralResponseInternalDTO(false, "Invalid credentials");
                }
                return new GeneralResponseInternalDTO(true, "Authentication successful");
            }
            catch (Exception ex)
            {
                return new GeneralResponseInternalDTO(false, ex.Message);
            }
        }
    }
}
