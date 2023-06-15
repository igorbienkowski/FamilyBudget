import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly TOKEN_KEY = 'auth_token';

  constructor() {}

  // Store token
  setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token);
  }

  // Retrieve token
  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  // Clear token
  clearToken(): void {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  // Check if the user is authenticated
  isAuthenticated(): boolean {
    return this.getToken() !== null;
  }
}
