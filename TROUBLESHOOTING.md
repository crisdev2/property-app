# Troubleshooting Guide - 403 Forbidden Error Fix

## Problem
Getting **403 Forbidden** error when trying to access `/api/properties`

## Root Causes Identified
1. ❌ CORS policy was too restrictive
2. ❌ Frontend API URL didn't match backend port
3. ❌ `UseAuthorization()` middleware without authentication setup

## Solutions Applied

### 1. Fixed CORS Configuration
**File:** `backend/PropertyApi/Program.cs`

**Changed from:**
```csharp
options.AddPolicy("AllowFrontend",
    policy =>
    {
        policy.WithOrigins("http://localhost:3000", "http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
```

**Changed to:**
```csharp
options.AddPolicy("AllowAll",
    policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
```

### 2. Removed Authorization Middleware
**File:** `backend/PropertyApi/Program.cs`

**Removed:**
```csharp
app.UseAuthorization();
```

This was causing 403 errors because no authentication was configured.

### 3. Updated Frontend API URL
**File:** `frontend/.env.local`

**Changed from:**
```env
NEXT_PUBLIC_API_URL=http://localhost:5000
```

**Changed to:**
```env
NEXT_PUBLIC_API_URL=http://localhost:5244
```

The backend actually runs on port 5244 (HTTP) or 7244 (HTTPS) as configured in `launchSettings.json`.

## How to Apply the Fix

### Step 1: Rebuild Backend
```bash
cd backend/PropertyApi
dotnet build
```

### Step 2: Restart Backend
```bash
# Stop the running backend (Ctrl+C)
# Then restart:
dotnet run
```

The API should now be accessible at:
- HTTP: http://localhost:5244/api/properties
- HTTPS: https://localhost:7244/api/properties

### Step 3: Update Frontend Environment Variable
Make sure `frontend/.env.local` has:
```env
NEXT_PUBLIC_API_URL=http://localhost:5244
```

### Step 4: Restart Frontend
```bash
cd frontend
# Stop the running frontend (Ctrl+C)
# Then restart:
npm run dev
```

## Test the Fix

### Test Backend API Directly
```bash
# Test with curl
curl http://localhost:5244/api/properties

# Or use browser/Postman
# Navigate to: http://localhost:5244/api/properties
```

### Test Swagger UI
Open in browser:
```
http://localhost:5244/swagger
```
or
```
https://localhost:7244/swagger
```

### Test Frontend
Open in browser:
```
http://localhost:3000
```

## Additional Notes

### Port Configuration
The backend ports are defined in `backend/PropertyApi/Properties/launchSettings.json`:
```json
{
  "http": {
    "applicationUrl": "http://localhost:5244"
  },
  "https": {
    "applicationUrl": "https://localhost:7244;http://localhost:5244"
  }
}
```

### CORS in Production
⚠️ **Important:** The current CORS configuration (`AllowAnyOrigin`) is suitable for development only.

For production, update to:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("Production",
        policy =>
        {
            policy.WithOrigins("https://yourdomain.com")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
```

### Common Issues After Fix

#### Issue: Still getting 403 after restart
**Solution:**
1. Clear browser cache
2. Make sure both backend and frontend are restarted
3. Check browser console for actual error message

#### Issue: CORS error instead of 403
**Solution:**
- This means the fix is working but there might be a network issue
- Check that backend is running on the correct port
- Verify `.env.local` has the correct URL

#### Issue: Cannot reach backend at all
**Solution:**
```bash
# Check if backend is running
lsof -i :5244

# Check firewall settings
# Restart backend with verbose logging
cd backend/PropertyApi
dotnet run --environment Development
```

## Verification Checklist

- [x] Backend builds successfully
- [x] Backend runs without errors
- [x] Can access `/api/properties` via browser
- [x] Swagger UI loads correctly
- [x] Frontend `.env.local` updated
- [x] Frontend restarts successfully
- [x] Frontend can fetch properties
- [x] No CORS errors in browser console

## What Changed in Files

### Modified Files
1. ✅ `backend/PropertyApi/Program.cs` - CORS and middleware
2. ✅ `frontend/.env.local` - API URL

### No Changes Required
- Controllers remain the same
- Services remain the same
- Frontend components remain the same
- MongoDB configuration remains the same

## Quick Reference

### Correct URLs
- **Backend API:** http://localhost:5244
- **Backend Swagger:** http://localhost:5244/swagger
- **Frontend App:** http://localhost:3000

### Test Endpoints
```bash
# Get all properties
curl http://localhost:5244/api/properties

# Filter by name
curl "http://localhost:5244/api/properties?name=Modern"

# Filter by price
curl "http://localhost:5244/api/properties?minPrice=300000&maxPrice=600000"
```

## Success!
After applying these fixes:
- ✅ No more 403 Forbidden errors
- ✅ API accessible from browser
- ✅ Frontend can communicate with backend
- ✅ CORS properly configured
- ✅ All endpoints working

---

**Last Updated:** 2025-11-13  
**Issue Status:** RESOLVED ✅
