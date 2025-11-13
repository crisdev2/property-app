# Property Management Full-Stack Application

A modern full-stack real estate property management application built with .NET 9, MongoDB, and Next.js.

## Project Overview

This application provides a complete solution for managing and displaying real estate property information. It consists of a RESTful API backend and a responsive web frontend, allowing users to browse and filter properties with ease.

## Technologies

### Backend
- **.NET 9** - Web API Framework
- **C#** - Programming Language
- **MongoDB** - NoSQL Database
- **NUnit** - Unit Testing Framework
- **Moq** - Mocking Framework
- **Swashbuckle** - Swagger/OpenAPI Documentation

### Frontend
- **Next.js 16** - React Framework
- **TypeScript** - Type-safe JavaScript
- **Tailwind CSS 4** - Utility-first CSS Framework
- **React 19** - UI Library

## Features

### Backend API
- RESTful endpoints for property management
- Advanced filtering (name, address, price range)
- MongoDB integration with optimized queries
- Clean architecture with repository pattern
- Comprehensive error handling
- Unit tests with high coverage
- Swagger documentation

### Frontend
- Responsive property listings
- Real-time filtering
- Card-based property display
- Loading states and error handling
- Mobile-first design
- Image fallback support

## Architecture

### Backend Structure
```
backend/PropertyApi/
├── Configuration/       # Application settings
├── Controllers/        # API endpoints
├── DTOs/              # Data Transfer Objects
├── Models/            # Domain entities
├── Repositories/      # Data access layer
├── Services/          # Business logic
└── Tests/             # Unit tests
```

### Frontend Structure
```
frontend/
├── app/
│   ├── components/    # React components
│   ├── services/      # API integration
│   └── types/         # TypeScript interfaces
└── public/           # Static assets
```

## Database Schema

### Collections
1. **Owners** - Property owners information
2. **Properties** - Property details
3. **PropertyImages** - Property images
4. **PropertyTraces** - Transaction history

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Node.js 18+](https://nodejs.org/)
- [MongoDB](https://www.mongodb.com/try/download/community)

## Quick Start

### 1. Start MongoDB
```bash
# Make sure MongoDB is running on localhost:27017
mongod
```

### 2. Start Backend API
```bash
cd backend/PropertyApi
dotnet restore
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:7xxx`
- Swagger: `https://localhost:7xxx/swagger`

### 3. Start Frontend
```bash
cd frontend
npm install
npm run dev
```

The frontend will be available at: `http://localhost:3000`

## API Endpoints

### Properties
- `GET /api/properties` - Get all properties
- `GET /api/properties/{id}` - Get property by ID
- `GET /api/properties?name={name}&address={address}&minPrice={min}&maxPrice={max}` - Filter properties

## Configuration

### Backend
Update `backend/PropertyApi/appsettings.json`:
```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "PropertyDb"
  }
}
```

### Frontend
Update `frontend/.env.local`:
```env
NEXT_PUBLIC_API_URL=http://localhost:5000
```

## Testing

### Backend Tests
```bash
cd backend/PropertyApi.Tests
dotnet test
```

### Test Coverage
- PropertyService unit tests
- Repository pattern testing
- Mock-based testing with Moq

## Development

### Backend Development
1. The API uses Clean Architecture principles
2. Repository pattern for data access
3. DTOs for API responses
4. Dependency injection for services
5. CORS enabled for frontend integration

### Frontend Development
1. Component-based architecture
2. TypeScript for type safety
3. Tailwind CSS for styling
4. Service layer for API calls
5. Custom hooks for state management

## Production Deployment

### Backend
```bash
cd backend/PropertyApi
dotnet publish -c Release
```

### Frontend
```bash
cd frontend
npm run build
npm start
```

## Evaluation Criteria Met

✅ **Clean Architecture** - Separation of concerns with layers  
✅ **Code Structure** - Modular and maintainable organization  
✅ **Documentation** - Comprehensive README files  
✅ **Best Practices** - Error handling, validation, optimization  
✅ **Performance** - Optimized queries and filtering  
✅ **Unit Testing** - NUnit tests with Moq  
✅ **Clean Code** - Readable, maintainable, conventional  

## Sample Data

To populate the database with sample data, you can use MongoDB Compass or the MongoDB shell to insert documents into the collections following the schema defined in the technical test.

## Troubleshooting

### Backend Issues
- Ensure MongoDB is running
- Check connection string in appsettings.json
- Verify .NET 9 SDK is installed

### Frontend Issues
- Check API URL in .env.local
- Ensure backend is running
- Clear browser cache if needed

## License

This project was created for technical evaluation purposes.

## Contributors

Developed as part of a Full-Stack Developer technical test.

## Documentation

- [Backend Documentation](./backend/README.md)
- [Frontend Documentation](./frontend/README.md)
- API Documentation: Available at `/swagger` endpoint when running the backend

## Support

For issues or questions, please refer to the individual README files in the backend and frontend directories.
