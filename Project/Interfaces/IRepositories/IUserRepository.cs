using Project.DTO.InternalDTO;
using Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public Task<GeneralResponseInternalDTO> AddUser(UserModel user);
        public Task<GeneralResponseInternalDTO> UserExist(string Email);
        //public Task<GeneralResponseInternalDTO> DeleteUser(UserModel user);
    }
}
