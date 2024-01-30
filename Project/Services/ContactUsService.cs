using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Interfaces.IServices;
using Project.Models;

namespace Project.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository _contactUsRepository;

        public ContactUsService(IContactUsRepository contactUsRepository)
        {
            _contactUsRepository = contactUsRepository;
        }

        public async Task<GeneralResponseInternalDTO> AddContact(ContactUsModel contact)
        {
            try
            {
                var result = await _contactUsRepository.AddContact(contact);
                return result;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
    }
}
