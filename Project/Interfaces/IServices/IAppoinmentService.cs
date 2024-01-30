using Microsoft.EntityFrameworkCore.Storage;
using Project.DTO.InternalDTO;
using Project.Models;

namespace Project.Interfaces.IServices
{
    public interface IAppoinmentService
    {
        public Task<GeneralResponseInternalDTO> AddAppoinment(AppointmentModel appoinment);
        public Task<GeneralResponseInternalDTO> AddAppoinmentSchedule(List<AppointmentSchedule> appointmentSchedules);
        public IDbContextTransaction BeginTransaction();
    }
}
