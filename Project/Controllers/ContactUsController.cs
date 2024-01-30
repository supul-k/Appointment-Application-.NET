using Microsoft.AspNetCore.Mvc;
using Project.DTO;
using Project.Interfaces.IServices;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;
        private readonly IValidationService _validationService;

        public ContactUsController(IContactUsService contactUsService, IValidationService validationService)
        {
            _contactUsService = contactUsService;
            _validationService = validationService;
        }

        [HttpPost("add-contact", Name = "AddContact")]
        public async Task<IActionResult> AddContact(ContactUsRequestDTO request)
        {
            try
            {
                ContactUsModel contact = new ContactUsModel();

                var emailValidation = await _validationService.ValidateEmail(request.Email);
                if (!emailValidation.Status)
                {
                    return BadRequest(emailValidation);
                }
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
