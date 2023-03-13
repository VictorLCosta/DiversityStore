import type { BaseEntity } from "@/types";

export type ProductDto = {
  name: string;
  slug: string;
  description: string;
  pictureUrl: string;
  price: number;
  quantityInStock: number;
} & BaseEntity;

export type ProductBriefDto = {
  name: string;
  slug: string;
  pictureUrl: string;
  price: number;
} & BaseEntity;

export type SaleItemDto = {
  productId: string;
  quantity: number;
};
