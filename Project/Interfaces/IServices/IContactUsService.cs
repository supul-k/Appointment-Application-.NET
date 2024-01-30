using Project.DTO.InternalDTO;
using Project.Models;

namespace Project.Interfaces.IServices
{
    public interface IContactUsService
    {
        public Task<GeneralResponseInternalDTO> AddContact(ContactUsModel contact);
    }
}
