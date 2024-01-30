using Project.DTO.InternalDTO;

namespace Project.Interfaces.IRepositories
{
    public interface IServiceTypeRepository
    {
        public Task<GeneralResponseInternalDTO> GetServiceTypes();
    }
}
