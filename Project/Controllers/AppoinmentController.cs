using Microsoft.AspNetCore.Mvc;
using Project.DataBaseAccess;
using Project.DTO;
using Project.Interfaces.IServices;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoinmentController : ControllerBase
    {
        private readonly IAppoinmentService _appoinmentService;
        private readonly IUserService _userService;
        private readonly IValidationService _validationService;

        public AppoinmentController(IAppoinmentService appoinmentService, IUserService userService, IValidationService validationService)
        {
            _appoinmentService = appoinmentService;
            _userService = userService;
            _validationService = validationService;
        }
        [HttpPost("add-appoinment", Name = "AddAppoinment")]
        public async Task<IActionResult> AddAppoinment(AppoinmentAddRequestDTO request)
        {
            using (var transaction = _appoinmentService.BeginTransaction())
            {
                try
                {
                    AppointmentModel appointment = new AppointmentModel();

                    var emailValidation = await _validationService.ValidateEmail(request.Email);
                    if (!emailValidation.Status)
                    {
                        return BadRequest(emailValidation);
                    }
                    Guid appoinmentId = Guid.NewGuid();
                    appointment.AppointmentId = appoinmentId.ToString();
                    appointment.ServiceTypeId = request.ServiceTypeId;
                    appointment.UserId = request.UserId;
                    appointment.SessionCount = request.SessionCount;
                    appointment.name = request.name;
                    appointment.contactNumber = request.ContactNumber;
                    appointment.Email = request.Email;

                    var result = await _appoinmentService.AddAppoinment(appointment);
                    if (!result.Status)
                    {
                        transaction.Rollback();
                        return BadRequest("Error adding appointment");
                    }

                    List<AppointmentSchedule> appointmentSchedules = new List<AppointmentSchedule>();
                    foreach (DateTime dateTime in request.AppointmentDateTimes)
                    {
                        AppointmentSchedule appointmentSchedule = new AppointmentSchedule();
                        {
                            Guid appointmentScheduleId = Guid.NewGuid();
                            appointmentSchedule.Id = appointmentScheduleId.ToString();
                            appointmentSchedule.AppointmentId = appoinmentId.ToString();
                            appointmentSchedule.DateTime = dateTime;
                        };

                        appointmentSchedules.Add(appointmentSchedule);                        
                    }
                    var result2 = await _appoinmentService.AddAppoinmentSchedule(appointmentSchedules);
                    if (!result2.Status)
                    {
                        transaction.Rollback();
                        return BadRequest("Error adding appointment schedule");
                    }
                    transaction.Commit();
                    return result.Status ? Created("Appoinment created", result) : BadRequest(result);

                }
                catch (Exception ex)
                {
                    GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                    return BadRequest(response);
                }
            }
        }

    }
}
