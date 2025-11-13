using PropertyApi.Models;

namespace PropertyApi.Repositories;

public interface IPropertyImageRepository
{
    Task<PropertyImage?> GetFirstEnabledImageByPropertyIdAsync(string propertyId);
    Task<IEnumerable<PropertyImage>> GetImagesByPropertyIdAsync(string propertyId);
}
