export interface PropertyDto {
  idProperty?: string;
  idOwner: string;
  name: string;
  address: string;
  price: number;
  image?: string;
}

export interface PropertyFilterDto {
  name?: string;
  address?: string;
  minPrice?: number;
  maxPrice?: number;
}
