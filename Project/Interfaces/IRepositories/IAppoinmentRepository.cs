using Project.DTO.InternalDTO;
using Project.Models;

namespace Project.Interfaces.IRepositories
{
    public interface IAppoinmentRepository
    {
        public Task<GeneralResponseInternalDTO> AddAppoinment(AppointmentModel appoinment);
        public Task<GeneralResponseInternalDTO> AddAppoinmentSchedule(List<AppointmentSchedule> appointmentSchedules);
    }
}
