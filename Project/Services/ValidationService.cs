using Project.DTO;
using Project.DTO.InternalDTO;
using Project.Interfaces.IServices;

namespace Project.Services
{
    public class ValidationService : IValidationService
    {
        public async Task<GeneralResponseInternalDTO> ValidatePassword(string password)
        {
            if (password.Length < 8)
            {
                return new GeneralResponseInternalDTO(false, "Password must be at least 8 characters long");
            }
            return new GeneralResponseInternalDTO(true, "Password is valid");
        }

        public async Task<GeneralResponseInternalDTO> ValidateEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return new GeneralResponseInternalDTO(true, "Email is valid");
            }
            catch (FormatException)
            {
                return new GeneralResponseInternalDTO(false, "Invalid email format");
            }
        }
    }
}
