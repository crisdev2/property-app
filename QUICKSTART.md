# Quick Start Guide - Property Management Application

## 🚀 Get Started in 5 Minutes

### Step 1: Prerequisites Check
```bash
# Check .NET version (should be 9.x)
dotnet --version

# Check Node.js version (should be 18+)
node --version

# Check MongoDB is running
mongosh --eval "db.version()"
```

### Step 2: Clone/Navigate to Project
```bash
cd property-app
```

### Step 3: Start MongoDB (if not running)
```bash
# macOS/Linux
mongod --dbpath /data/db

# Or use MongoDB as a service
brew services start mongodb-community
```

### Step 4: Load Sample Data (Optional)
```bash
# From project root
mongosh < backend/sample-data.js
```

### Step 5: Start Backend API
```bash
# Terminal 1
cd backend/PropertyApi
dotnet restore
dotnet run

# API will be available at:
# - https://localhost:7xxx/api/properties
# - https://localhost:7xxx/swagger (API docs)
```

### Step 6: Start Frontend
```bash
# Terminal 2 (new terminal)
cd frontend
npm install
npm run dev

# Frontend will be available at:
# - http://localhost:3000
```

### Step 7: Test the Application

**Open your browser:**
- Frontend: http://localhost:3000
- Backend Swagger: https://localhost:7xxx/swagger

**Try these actions:**
1. View all properties on the homepage
2. Filter by name: type "Modern"
3. Filter by price: set min $300,000 and max $600,000
4. Filter by address: type "Seattle"
5. Click "Reset" to clear filters

### Step 8: Run Tests (Optional)
```bash
# Terminal 3 (new terminal)
cd backend/PropertyApi.Tests
dotnet test

# Expected output: 5 passed tests
```

## 📝 Default Ports

| Service | Port | URL |
|---------|------|-----|
| Frontend | 3000 | http://localhost:3000 |
| Backend API | 5000/7xxx | https://localhost:7xxx |
| Swagger | 7xxx | https://localhost:7xxx/swagger |
| MongoDB | 27017 | mongodb://localhost:27017 |

## 🔧 Configuration Files

### Backend Configuration
**File:** `backend/PropertyApi/appsettings.json`
```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "PropertyDb"
  }
}
```

### Frontend Configuration
**File:** `frontend/.env.local`
```env
NEXT_PUBLIC_API_URL=http://localhost:5000
```

## 🐛 Troubleshooting

### Problem: "MongoDB connection failed"
**Solution:**
```bash
# Check if MongoDB is running
ps aux | grep mongo

# Start MongoDB
mongod
```

### Problem: "Port already in use"
**Solution:**
```bash
# Find process using port (e.g., 5000)
lsof -ti:5000

# Kill the process
kill -9 $(lsof -ti:5000)
```

### Problem: "Cannot find module"
**Solution:**
```bash
# Backend
cd backend/PropertyApi
dotnet restore

# Frontend
cd frontend
npm install
```

### Problem: "CORS error"
**Solution:**
- Check that API URL in `.env.local` matches backend URL
- Restart both frontend and backend

### Problem: "No properties showing"
**Solution:**
```bash
# Load sample data
mongosh < backend/sample-data.js

# Or check MongoDB
mongosh
use PropertyDb
db.Properties.find()
```

## 📊 Sample Data

The `backend/sample-data.js` file includes:
- 3 Owners
- 6 Properties
- 6 Property Images
- 6 Property Traces

**Properties included:**
1. Modern Downtown Apartment - $450,000
2. Luxury Waterfront Condo - $850,000
3. Cozy Suburban House - $325,000
4. Spacious Family Home - $520,000
5. Penthouse Suite - $1,200,000
6. Charming Victorian - $975,000

## 🧪 Testing the API Manually

### Using Swagger UI
1. Open https://localhost:7xxx/swagger
2. Expand "GET /api/properties"
3. Click "Try it out"
4. Click "Execute"
5. View response

### Using curl
```bash
# Get all properties
curl -k https://localhost:7xxx/api/properties

# Filter by name
curl -k "https://localhost:7xxx/api/properties?name=Modern"

# Filter by price range
curl -k "https://localhost:7xxx/api/properties?minPrice=300000&maxPrice=600000"

# Filter by address
curl -k "https://localhost:7xxx/api/properties?address=Seattle"
```

## 📦 Project Structure
```
property-app/
├── backend/
│   ├── PropertyApi/           # Main API project
│   ├── PropertyApi.Tests/     # Unit tests
│   ├── sample-data.js         # MongoDB seed data
│   └── README.md
├── frontend/
│   ├── app/                   # Next.js app directory
│   │   ├── components/        # React components
│   │   ├── services/          # API services
│   │   └── types/             # TypeScript types
│   └── README.md
├── README.md                  # Main documentation
├── PROJECT_SUMMARY.md         # Technical summary
└── QUICKSTART.md             # This file
```

## 🎯 Next Steps

1. **Explore the Code:**
   - Review `backend/PropertyApi/Controllers/PropertiesController.cs`
   - Check `frontend/app/page.tsx` for main UI
   - Look at `backend/PropertyApi/Services/PropertyService.cs` for business logic

2. **Customize:**
   - Add more properties via MongoDB
   - Modify filters in frontend
   - Extend API with new endpoints

3. **Deploy:**
   - Backend: Azure, AWS, or Heroku
   - Frontend: Vercel, Netlify, or AWS Amplify
   - Database: MongoDB Atlas (cloud)

## 📚 Documentation

- **Main README**: `README.md` - Project overview
- **Backend README**: `backend/README.md` - API documentation
- **Frontend README**: `frontend/README.md` - UI documentation
- **Project Summary**: `PROJECT_SUMMARY.md` - Technical details

## 🤝 Support

For issues:
1. Check console logs in browser (F12)
2. Check terminal output for errors
3. Review MongoDB logs
4. Consult README files

## ✅ Checklist

- [ ] MongoDB running
- [ ] Sample data loaded
- [ ] Backend running on port 7xxx
- [ ] Frontend running on port 3000
- [ ] Can view properties
- [ ] Can filter properties
- [ ] Tests passing

---

**Congratulations!** 🎉 You now have a fully functional property management application running locally.
