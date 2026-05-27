import { config } from "../config";
import type { User } from "../types/responses/User";

const API_URL = `${config.api.url}/api/users`;

export async function getUsers(): Promise<User[]> {
  try {
    const response = await fetch(API_URL);

    if (!response.ok) {
        throw new Error('Cant get user');
    }
    return await response.json();
  } catch (error) {
    console.error('Error on UserService' + error);
    throw error;
  }
}
