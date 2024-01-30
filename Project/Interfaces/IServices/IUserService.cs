using Project.DTO.InternalDTO;
using Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Interfaces.IServices
{
    public interface IUserService
    {
        public Task<GeneralResponseInternalDTO> AddUser(UserModel user);
        public Task<GeneralResponseInternalDTO> UserExist(string Email);
        public Task<GeneralResponseInternalDTO> AuthenticateUser(string password, string hashedPassword);
    }
}
