using Microsoft.AspNetCore.Mvc;
using Project.DTO;
using Project.DTO.InternalDTO;
using Project.Interfaces.IServices;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService serviceTypeService;

        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            this.serviceTypeService = serviceTypeService;
        }

        [HttpGet("get-all-services", Name = "GetServiceTypes")]
        public async Task<IActionResult> GetServiceTypes()
        {
            try
            {
                var serviceTypes = await serviceTypeService.GetServiceTypes();

                if (serviceTypes != null)
                {
                    return Ok(new GeneralResponseInternalDTO(true, serviceTypes, "Service types retrieved successfully"));
                }
                else
                {
                    return NotFound(new GeneralResponseInternalDTO(false, "No service types found", null));
                }
            }
            catch (Exception ex)
            {
                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
