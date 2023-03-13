import type { BaseEntity } from "@/types";

export type ProductBriefDto = {
  name: string;
  slug: string;
  pictureUrl: string;
  price: number;
} & BaseEntity;
