using MongoDB.Driver;
using PropertyApi.Models;
using PropertyApi.Configuration;
using PropertyApi.DTOs;
using Microsoft.Extensions.Options;

namespace PropertyApi.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly IMongoCollection<Property> _properties;

    public PropertyRepository(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _properties = mongoDatabase.GetCollection<Property>(mongoDbSettings.Value.PropertiesCollectionName);
    }

    public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
    {
        return await _properties.Find(_ => true).ToListAsync();
    }

    public async Task<Property?> GetPropertyByIdAsync(string id)
    {
        return await _properties.Find(p => p.IdProperty == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Property>> GetFilteredPropertiesAsync(PropertyFilterDto filter)
    {
        var filterBuilder = Builders<Property>.Filter;
        var filters = new List<FilterDefinition<Property>>();

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            filters.Add(filterBuilder.Regex(p => p.Name, new MongoDB.Bson.BsonRegularExpression(filter.Name, "i")));
        }

        if (!string.IsNullOrWhiteSpace(filter.Address))
        {
            filters.Add(filterBuilder.Regex(p => p.Address, new MongoDB.Bson.BsonRegularExpression(filter.Address, "i")));
        }

        if (filter.MinPrice.HasValue)
        {
            filters.Add(filterBuilder.Gte(p => p.Price, filter.MinPrice.Value));
        }

        if (filter.MaxPrice.HasValue)
        {
            filters.Add(filterBuilder.Lte(p => p.Price, filter.MaxPrice.Value));
        }

        var combinedFilter = filters.Count > 0 ? filterBuilder.And(filters) : filterBuilder.Empty;

        return await _properties.Find(combinedFilter).ToListAsync();
    }

    public async Task<Property> CreatePropertyAsync(Property property)
    {
        await _properties.InsertOneAsync(property);
        return property;
    }

    public async Task<bool> UpdatePropertyAsync(string id, Property property)
    {
        var result = await _properties.ReplaceOneAsync(p => p.IdProperty == id, property);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeletePropertyAsync(string id)
    {
        var result = await _properties.DeleteOneAsync(p => p.IdProperty == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}
