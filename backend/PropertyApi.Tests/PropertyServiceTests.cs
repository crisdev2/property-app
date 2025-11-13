using NUnit.Framework;
using Moq;
using PropertyApi.Services;
using PropertyApi.Repositories;
using PropertyApi.Models;
using PropertyApi.DTOs;

namespace PropertyApi.Tests;

[TestFixture]
public class PropertyServiceTests
{
    private Mock<IPropertyRepository> _mockPropertyRepository;
    private Mock<IPropertyImageRepository> _mockPropertyImageRepository;
    private PropertyService _propertyService;

    [SetUp]
    public void Setup()
    {
        _mockPropertyRepository = new Mock<IPropertyRepository>();
        _mockPropertyImageRepository = new Mock<IPropertyImageRepository>();
        _propertyService = new PropertyService(_mockPropertyRepository.Object, _mockPropertyImageRepository.Object);
    }

    [Test]
    public async Task GetAllPropertiesAsync_ShouldReturnPropertyDtos()
    {
        // Arrange
        var properties = new List<Property>
        {
            new Property
            {
                IdProperty = "1",
                IdOwner = "owner1",
                Name = "Test Property",
                Address = "123 Test St",
                Price = 100000m
            }
        };

        var image = new PropertyImage
        {
            IdPropertyImage = "img1",
            IdProperty = "1",
            File = "test.jpg",
            Enabled = true
        };

        _mockPropertyRepository.Setup(r => r.GetAllPropertiesAsync())
            .ReturnsAsync(properties);
        _mockPropertyImageRepository.Setup(r => r.GetFirstEnabledImageByPropertyIdAsync("1"))
            .ReturnsAsync(image);

        // Act
        var result = await _propertyService.GetAllPropertiesAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
        var propertyDto = result.First();
        Assert.That(propertyDto.Name, Is.EqualTo("Test Property"));
        Assert.That(propertyDto.Image, Is.EqualTo("test.jpg"));
    }

    [Test]
    public async Task GetPropertyByIdAsync_ShouldReturnPropertyDto_WhenPropertyExists()
    {
        // Arrange
        var property = new Property
        {
            IdProperty = "1",
            IdOwner = "owner1",
            Name = "Test Property",
            Address = "123 Test St",
            Price = 100000m
        };

        var image = new PropertyImage
        {
            IdPropertyImage = "img1",
            IdProperty = "1",
            File = "test.jpg",
            Enabled = true
        };

        _mockPropertyRepository.Setup(r => r.GetPropertyByIdAsync("1"))
            .ReturnsAsync(property);
        _mockPropertyImageRepository.Setup(r => r.GetFirstEnabledImageByPropertyIdAsync("1"))
            .ReturnsAsync(image);

        // Act
        var result = await _propertyService.GetPropertyByIdAsync("1");

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Name, Is.EqualTo("Test Property"));
        Assert.That(result.Image, Is.EqualTo("test.jpg"));
    }

    [Test]
    public async Task GetPropertyByIdAsync_ShouldReturnNull_WhenPropertyDoesNotExist()
    {
        // Arrange
        _mockPropertyRepository.Setup(r => r.GetPropertyByIdAsync("999"))
            .ReturnsAsync((Property?)null);

        // Act
        var result = await _propertyService.GetPropertyByIdAsync("999");

        // Assert
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task GetFilteredPropertiesAsync_ShouldReturnFilteredProperties()
    {
        // Arrange
        var filter = new PropertyFilterDto
        {
            Name = "Test",
            MinPrice = 50000m,
            MaxPrice = 150000m
        };

        var properties = new List<Property>
        {
            new Property
            {
                IdProperty = "1",
                IdOwner = "owner1",
                Name = "Test Property",
                Address = "123 Test St",
                Price = 100000m
            }
        };

        _mockPropertyRepository.Setup(r => r.GetFilteredPropertiesAsync(filter))
            .ReturnsAsync(properties);
        _mockPropertyImageRepository.Setup(r => r.GetFirstEnabledImageByPropertyIdAsync("1"))
            .ReturnsAsync((PropertyImage?)null);

        // Act
        var result = await _propertyService.GetFilteredPropertiesAsync(filter);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().Name, Is.EqualTo("Test Property"));
    }
}
