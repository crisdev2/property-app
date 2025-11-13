using MongoDB.Driver;
using PropertyApi.Models;
using PropertyApi.Configuration;
using Microsoft.Extensions.Options;

namespace PropertyApi.Repositories;

public class PropertyImageRepository : IPropertyImageRepository
{
    private readonly IMongoCollection<PropertyImage> _propertyImages;

    public PropertyImageRepository(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _propertyImages = mongoDatabase.GetCollection<PropertyImage>(mongoDbSettings.Value.PropertyImagesCollectionName);
    }

    public async Task<PropertyImage?> GetFirstEnabledImageByPropertyIdAsync(string propertyId)
    {
        return await _propertyImages
            .Find(pi => pi.IdProperty == propertyId && pi.Enabled)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PropertyImage>> GetImagesByPropertyIdAsync(string propertyId)
    {
        return await _propertyImages
            .Find(pi => pi.IdProperty == propertyId)
            .ToListAsync();
    }
}
