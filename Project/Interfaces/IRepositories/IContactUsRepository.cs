using Project.DTO.InternalDTO;
using Project.Models;

namespace Project.Interfaces.IRepositories
{
    public interface IContactUsRepository
    {
        public Task<GeneralResponseInternalDTO> AddContact(ContactUsModel contact);
    }
}
