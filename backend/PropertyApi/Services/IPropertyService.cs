using PropertyApi.DTOs;

namespace PropertyApi.Services;

public interface IPropertyService
{
    Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync();
    Task<PropertyDto?> GetPropertyByIdAsync(string id);
    Task<IEnumerable<PropertyDto>> GetFilteredPropertiesAsync(PropertyFilterDto filter);
}
