import { config } from "../config";
import type { User } from "../types/responses/User";

const API_URL = `${config.api.url}/api/users`;
const TOKEN = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYmxhemUiLCJleHRlcm5hbElkIjoiOWIyZTc4NDktMGIzZi00MGZlLTliNzctYzUxMzg5ODVjNDVkIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW5pc3RyYXRvciIsImV4cCI6MTc3OTkxMTg5NiwiaXNzIjoibWktYXBpIiwiYXVkIjoibWktYXBpLWNsaWVudCJ9.943ewlNPVTn2MU4d2g-tMzEISITmRq5QkYZWIwn8Izo';

export async function getUsers(): Promise<User[]> {
  try {
    const response = await fetch(API_URL,{
      headers:{
        'Authorization':`Bearer ${TOKEN}`
      }
    });

    if (!response.ok) {
        throw new Error('Cant get user');
    }
    return await response.json();
  } catch (error) {
    console.error('Error on UserService' + error);
    throw error;
  }
}
