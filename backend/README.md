# Property API - Backend

A RESTful API built with .NET 9 and MongoDB for managing real estate property data.

## Technologies

- **.NET 9** - Web API Framework
- **C#** - Programming Language
- **MongoDB** - NoSQL Database
- **NUnit** - Unit Testing Framework
- **Moq** - Mocking Framework
- **Swashbuckle** - Swagger/OpenAPI Documentation

## Architecture

The project follows Clean Architecture principles with the following layers:

- **Models**: Domain entities (Owner, Property, PropertyImage, PropertyTrace)
- **DTOs**: Data Transfer Objects for API responses
- **Repositories**: Data access layer with MongoDB operations
- **Services**: Business logic layer
- **Controllers**: API endpoints and request handling

## Features

- Get all properties with images
- Get property by ID
- Filter properties by:
  - Name (case-insensitive search)
  - Address (case-insensitive search)
  - Price range (min/max)
- Automatic image fetching (first enabled image per property)
- CORS enabled for frontend integration
- Swagger UI for API documentation

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [MongoDB](https://www.mongodb.com/try/download/community) (running on localhost:27017)

## Setup

1. **Clone the repository**

2. **Configure MongoDB**

   Update `appsettings.json` with your MongoDB connection string if different from default:
   ```json
   "MongoDbSettings": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "PropertyDb"
   }
   ```

3. **Restore dependencies**
   ```bash
   cd backend/PropertyApi
   dotnet restore
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

   The API will be available at:
   - HTTPS: `https://localhost:7xxx`
   - HTTP: `http://localhost:5xxx`
   - Swagger UI: `https://localhost:7xxx/swagger`

## API Endpoints

### Get All Properties
```
GET /api/properties
```

### Get Property by ID
```
GET /api/properties/{id}
```

### Filter Properties
```
GET /api/properties?name={name}&address={address}&minPrice={min}&maxPrice={max}
```

**Query Parameters:**
- `name` (optional): Filter by property name
- `address` (optional): Filter by address
- `minPrice` (optional): Minimum price
- `maxPrice` (optional): Maximum price

## Testing

Run unit tests:
```bash
cd backend/PropertyApi.Tests
dotnet test
```

## Database Collections

The API uses the following MongoDB collections:

- **Properties**: Property information
- **Owners**: Owner details
- **PropertyImages**: Property images
- **PropertyTraces**: Property transaction history

## Sample Data Structure

### Property
```json
{
  "idProperty": "507f1f77bcf86cd799439011",
  "name": "Modern Downtown Apartment",
  "address": "123 Main St, City",
  "price": 250000,
  "codeInternal": "PROP-001",
  "year": 2020,
  "idOwner": "507f1f77bcf86cd799439012"
}
```

### PropertyImage
```json
{
  "idPropertyImage": "507f1f77bcf86cd799439013",
  "idProperty": "507f1f77bcf86cd799439011",
  "file": "https://example.com/image.jpg",
  "enabled": true
}
```

## Error Handling

The API implements proper error handling:
- 200 OK: Successful requests
- 404 Not Found: Resource not found
- 500 Internal Server Error: Server errors with logged details

## CORS Configuration

CORS is enabled for:
- `http://localhost:3000` (React default)
- `http://localhost:5173` (Vite default)

Update `Program.cs` to add more origins if needed.
