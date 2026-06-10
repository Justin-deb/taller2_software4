import type { Product } from "../types/responses/Product";
import { config } from "../config";

const API_URL = `${config.api.url}/api/products`;

export async function getProducts(): Promise<Product[]> {
  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
        throw new Error('Cant get products');
    }
    return await response.json();
  } catch (error) {
    console.error('Error on ProductService' + error);
    throw error;
  }
}
