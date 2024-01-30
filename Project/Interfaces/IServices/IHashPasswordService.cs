using Project.DTO.InternalDTO;
using Project.Models;

namespace Project.Interfaces.IServices
{
    public interface IHashPasswordService
    {
        public Task<GeneralResponseInternalDTO> HashPassword(string password);
        public Task<GeneralResponseInternalDTO> VerifyPassword(string password, string hashedPassword);
    }
}
