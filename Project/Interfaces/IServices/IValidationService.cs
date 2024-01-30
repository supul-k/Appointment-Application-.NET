using Project.DTO;
using Project.DTO.InternalDTO;

namespace Project.Interfaces.IServices
{
    public interface IValidationService
    {
        public Task<GeneralResponseInternalDTO> ValidatePassword(string password);
        public Task<GeneralResponseInternalDTO> ValidateEmail(string email);
    }
}
