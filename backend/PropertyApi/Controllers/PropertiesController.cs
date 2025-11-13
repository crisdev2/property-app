using Microsoft.AspNetCore.Mvc;
using PropertyApi.Services;
using PropertyApi.DTOs;

namespace PropertyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    private readonly ILogger<PropertiesController> _logger;

    public PropertiesController(
        IPropertyService propertyService,
        ILogger<PropertiesController> logger)
    {
        _propertyService = propertyService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PropertyDto>>> GetProperties([FromQuery] PropertyFilterDto? filter)
    {
        try
        {
            if (filter != null && (filter.Name != null || filter.Address != null || filter.MinPrice.HasValue || filter.MaxPrice.HasValue))
            {
                var properties = await _propertyService.GetFilteredPropertiesAsync(filter);
                return Ok(properties);
            }

            var allProperties = await _propertyService.GetAllPropertiesAsync();
            return Ok(allProperties);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving properties");
            return StatusCode(500, "An error occurred while retrieving properties");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PropertyDto>> GetProperty(string id)
    {
        try
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            
            if (property == null)
                return NotFound($"Property with ID {id} not found");

            return Ok(property);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving property with ID {PropertyId}", id);
            return StatusCode(500, "An error occurred while retrieving the property");
        }
    }
}
