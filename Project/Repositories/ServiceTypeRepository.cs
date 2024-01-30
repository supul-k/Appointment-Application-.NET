using Microsoft.EntityFrameworkCore;
using Project.DataBaseAccess;
using Project.DTO;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;

namespace Project.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GeneralResponseInternalDTO> GetServiceTypes()
        {
            try
            {
                var serviceTypes = await _context.ServiceTypes.ToListAsync();
                return new GeneralResponseInternalDTO(true, serviceTypes, "Service types retrieved successfully");
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
    }
}
