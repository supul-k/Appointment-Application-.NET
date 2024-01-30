using Project.DataBaseAccess;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Models;

namespace Project.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactUsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> AddContact(ContactUsModel contact)
        {
            try
            {
                _context.ContactUs.Add(contact);
                await _context.SaveChangesAsync();
                var response = new GeneralResponseInternalDTO(true, "Message added successfully");
                return response;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
    }
}
