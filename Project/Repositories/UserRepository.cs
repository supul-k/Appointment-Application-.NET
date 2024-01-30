using Microsoft.EntityFrameworkCore;
using Project.DataBaseAccess;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;   
        }
        public async Task<GeneralResponseInternalDTO> AddUser(UserModel user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                var response = new GeneralResponseInternalDTO(true,"User added successfully");
                return response;
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
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email);
                await _context.SaveChangesAsync();
                var response = new GeneralResponseInternalDTO(true, existingUser, "User Found");
                return response;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }

        public async Task<GeneralResponseInternalDTO> DeleteUser(UserModel user)
        {
            var response = new GeneralResponseInternalDTO(true, "User added successfully");
            return response;
        }
    }
}
