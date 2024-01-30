using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Interfaces.IServices;
using Project.Models;
using Project.DataBaseAccess;

namespace Project.Services
{
    public class AppoinmentService : IAppoinmentService
    {
        private readonly IAppoinmentRepository _appoinmentRepository;
        private readonly ApplicationDbContext _context;

        public AppoinmentService(IAppoinmentRepository appoinmentRepository, ApplicationDbContext context)
        {
            _appoinmentRepository = appoinmentRepository;
            _context = context;
        }
        public async Task<GeneralResponseInternalDTO> AddAppoinment(AppointmentModel appoinment)
        {
            try
            {
                var result = await _appoinmentRepository.AddAppoinment(appoinment);
                return result;
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
                var result = await _appoinmentRepository.AddAppoinmentSchedule(appointmentSchedules);
                return result;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
