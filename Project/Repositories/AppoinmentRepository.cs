using Project.DataBaseAccess;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Models;

namespace Project.Repositories
{
    public class AppoinmentRepository : IAppoinmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppoinmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<GeneralResponseInternalDTO> AddAppoinment(AppointmentModel appoinment)
        {
            try
            {
                _context.Appointments.Add(appoinment);
                await _context.SaveChangesAsync();
                var response = new GeneralResponseInternalDTO(true, "Appoinment added successfully");
                return response;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
        public async Task<GeneralResponseInternalDTO> AddAppoinmentSchedule(List<AppointmentSchedule> appointmentSchedules)
        {
            try
            {
                _context.AppointmentSchedules.AddRange(appointmentSchedules);
                await _context.SaveChangesAsync();
                var response = new GeneralResponseInternalDTO(true, "Appoinment Schedule added successfully");
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
