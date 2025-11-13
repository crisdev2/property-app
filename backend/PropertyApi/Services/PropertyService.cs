using PropertyApi.DTOs;
using PropertyApi.Repositories;

namespace PropertyApi.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IPropertyImageRepository _propertyImageRepository;

    public PropertyService(
        IPropertyRepository propertyRepository,
        IPropertyImageRepository propertyImageRepository)
    {
        _propertyRepository = propertyRepository;
        _propertyImageRepository = propertyImageRepository;
    }

    public async Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync()
    {
        var properties = await _propertyRepository.GetAllPropertiesAsync();
        var propertyDtos = new List<PropertyDto>();

        foreach (var property in properties)
        {
            var image = await _propertyImageRepository.GetFirstEnabledImageByPropertyIdAsync(property.IdProperty!);
            
            propertyDtos.Add(new PropertyDto
            {
                IdProperty = property.IdProperty,
                IdOwner = property.IdOwner,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                Image = image?.File
            });
        }

        return propertyDtos;
    }

    public async Task<PropertyDto?> GetPropertyByIdAsync(string id)
    {
        var property = await _propertyRepository.GetPropertyByIdAsync(id);
        if (property == null)
            return null;

        var image = await _propertyImageRepository.GetFirstEnabledImageByPropertyIdAsync(property.IdProperty!);

        return new PropertyDto
        {
            IdProperty = property.IdProperty,
            IdOwner = property.IdOwner,
            Name = property.Name,
            Address = property.Address,
            Price = property.Price,
            Image = image?.File
        };
    }

    public async Task<IEnumerable<PropertyDto>> GetFilteredPropertiesAsync(PropertyFilterDto filter)
    {
        var properties = await _propertyRepository.GetFilteredPropertiesAsync(filter);
        var propertyDtos = new List<PropertyDto>();

        foreach (var property in properties)
        {
            var image = await _propertyImageRepository.GetFirstEnabledImageByPropertyIdAsync(property.IdProperty!);
            
            propertyDtos.Add(new PropertyDto
            {
                IdProperty = property.IdProperty,
                IdOwner = property.IdOwner,
                Name = property.Name,
                Address = property.Address,
                Price = property.Price,
                Image = image?.File
            });
        }

        return propertyDtos;
    }
}
