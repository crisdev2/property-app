import { PropertyDto, PropertyFilterDto } from '../types/property';

const API_BASE_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5000';

export const propertyService = {
  async getAllProperties(): Promise<PropertyDto[]> {
    const response = await fetch(`${API_BASE_URL}/api/properties`);
    if (!response.ok) {
      throw new Error('Failed to fetch properties');
    }
    return response.json();
  },

  async getPropertyById(id: string): Promise<PropertyDto> {
    const response = await fetch(`${API_BASE_URL}/api/properties/${id}`);
    if (!response.ok) {
      throw new Error('Failed to fetch property');
    }
    return response.json();
  },

  async getFilteredProperties(filter: PropertyFilterDto): Promise<PropertyDto[]> {
    const params = new URLSearchParams();
    if (filter.name) params.append('name', filter.name);
    if (filter.address) params.append('address', filter.address);
    if (filter.minPrice !== undefined) params.append('minPrice', filter.minPrice.toString());
    if (filter.maxPrice !== undefined) params.append('maxPrice', filter.maxPrice.toString());

    const response = await fetch(`${API_BASE_URL}/api/properties?${params.toString()}`);
    if (!response.ok) {
      throw new Error('Failed to fetch filtered properties');
    }
    return response.json();
  },
};
