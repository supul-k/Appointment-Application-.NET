using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Interfaces.IServices;

namespace Project.Services
{
    public class ServiceTypeService : IServiceTypeService
    {
        private readonly IServiceTypeRepository _serviceTypeRepository;

        public ServiceTypeService(IServiceTypeRepository serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public async Task<GeneralResponseInternalDTO> GetServiceTypes()
        {
            try
            {
                var result = await _serviceTypeRepository.GetServiceTypes();
                return result;
            }
            catch (Exception ex)
            {
                var response = new GeneralResponseInternalDTO(false, ex.Message);
                return response;
            }
        }
    }
}
