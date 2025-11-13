# Property Listings - Frontend

A modern, responsive web application built with Next.js and TypeScript for browsing and filtering real estate properties.

## Technologies

- **Next.js 16** - React Framework
- **TypeScript** - Type-safe JavaScript
- **Tailwind CSS 4** - Utility-first CSS Framework
- **React 19** - UI Library

## Features

- **Property Listing**: Display all available properties in a card-based grid layout
- **Advanced Filtering**: Filter properties by:
  - Property name (case-insensitive search)
  - Address (case-insensitive search)
  - Price range (min/max)
- **Responsive Design**: Optimized for desktop, tablet, and mobile devices
- **Loading States**: Visual feedback during data fetching
- **Error Handling**: User-friendly error messages
- **Image Fallback**: Placeholder for properties without images

## Prerequisites

- [Node.js 18+](https://nodejs.org/) (or use the version installed)
- Backend API running (see backend README)

## Setup

1. **Install dependencies**
   ```bash
   cd frontend
   npm install
   ```

2. **Configure API URL**
   
   Create or update `.env.local`:
   ```env
   NEXT_PUBLIC_API_URL=http://localhost:5000
   ```

3. **Run the development server**
   ```bash
   npm run dev
   ```

   The application will be available at: `http://localhost:3000`

## Available Scripts

- `npm run dev` - Start development server
- `npm run build` - Build for production
- `npm start` - Start production server
- `npm run lint` - Run ESLint

## Project Structure

```
frontend/
├── app/
│   ├── components/          # React components
│   │   ├── PropertyCard.tsx    # Individual property card
│   │   ├── PropertyFilters.tsx # Filter form
│   │   └── PropertyList.tsx    # Properties grid
│   ├── services/            # API services
│   │   └── propertyService.ts  # Property API calls
│   ├── types/               # TypeScript types
│   │   └── property.ts         # Property interfaces
│   ├── globals.css          # Global styles
│   ├── layout.tsx           # Root layout
│   └── page.tsx             # Home page
├── public/                  # Static assets
├── .env.local              # Environment variables
├── next.config.js          # Next.js configuration
├── tailwind.config.js      # Tailwind configuration
├── tsconfig.json           # TypeScript configuration
└── package.json            # Dependencies
```

## Components

### PropertyCard
Displays individual property information including:
- Property image (with fallback)
- Property name
- Address with location icon
- Price (formatted as currency)
- "View Details" button

### PropertyFilters
Filter form with inputs for:
- Property name search
- Address search
- Minimum price
- Maximum price
- Search and Reset buttons

### PropertyList
Manages property display with:
- Loading spinner
- Error messages
- Empty state
- Property count
- Grid layout of PropertyCards

## API Integration

The frontend communicates with the backend API through `propertyService`:

```typescript
// Get all properties
propertyService.getAllProperties()

// Get property by ID
propertyService.getPropertyById(id)

// Filter properties
propertyService.getFilteredProperties(filter)
```

## Styling

- Uses **Tailwind CSS** for utility-first styling
- Responsive grid layout (1 col mobile, 2 cols tablet, 3 cols desktop)
- Hover effects and transitions
- Custom color scheme with blue accent
- Dark mode support in gradient backgrounds

## Environment Variables

- `NEXT_PUBLIC_API_URL` - Backend API base URL (default: http://localhost:5000)

## Building for Production

```bash
npm run build
npm start
```

The optimized production build will be available at `http://localhost:3000`.

## Browser Support

- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

## Future Enhancements

- Property detail pages
- Pagination for large datasets
- Save favorite properties
- Property comparison
- Map view integration
- Authentication
- Property submission form
