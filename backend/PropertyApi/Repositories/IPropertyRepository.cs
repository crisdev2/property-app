using PropertyApi.Models;
using PropertyApi.DTOs;

namespace PropertyApi.Repositories;

public interface IPropertyRepository
{
    Task<IEnumerable<Property>> GetAllPropertiesAsync();
    Task<Property?> GetPropertyByIdAsync(string id);
    Task<IEnumerable<Property>> GetFilteredPropertiesAsync(PropertyFilterDto filter);
    Task<Property> CreatePropertyAsync(Property property);
    Task<bool> UpdatePropertyAsync(string id, Property property);
    Task<bool> DeletePropertyAsync(string id);
}
