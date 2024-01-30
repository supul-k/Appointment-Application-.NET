using Microsoft.AspNetCore.Mvc;
using Project.DTO;
using Project.Interfaces.IServices;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpPost("add-contact", Name = "AddContact")]
        public async Task<IActionResult> AddContact(ContactUsRequestDTO request)
        {
            try
            {
                ContactUsModel contact = new ContactUsModel();

                Guid ContactId = Guid.NewGuid();
                contact.ContactId = ContactId.ToString();
                contact.ContactNumber = request.ContactNumber;
                contact.Email = request.Email;
                contact.Message = request.Message;
                contact.MessageType = request.MessageType;
                var result =  await _contactUsService.AddContact(contact);

                return result.Status ? Created("Contact created", result) : BadRequest(result);
            }
            catch (Exception ex)
            {
                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
