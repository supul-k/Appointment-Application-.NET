using Project.DTO.InternalDTO;

namespace Project.Interfaces.IServices
{
    public interface IServiceTypeService
    {
        public Task<GeneralResponseInternalDTO> GetServiceTypes();
    }
}
