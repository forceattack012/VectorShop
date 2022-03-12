import { Injectable } from '@angular/core';
import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { Login } from 'src/app/shared/models/login';

@Injectable({
  providedIn: 'root'
})
export class AuthenService {

  private manager = new UserManager(getClientSettings());
  private user: User | null | undefined;

  constructor(private http: HttpClient) {
    this.manager.getUser().then((user) => {
      this.user = user;
    });
  }

  getUser(): User | null | undefined {
    return this.user;
  }

  getToken(): string | undefined {
    return this.user?.access_token;
  }

  login(login: Login): void {

  }
}

export function getClientSettings(): UserManagerSettings {
  return {
      authority: 'http://localhost:8083',
      client_id: 'angular_spa',
      redirect_uri: 'http://localhost:4200/auth-callback',
      post_logout_redirect_uri: 'http://localhost:4200/',
      response_type: 'id_token token',
      scope:'openid profile email api.read',
      filterProtocolClaims: true,
      loadUserInfo: true,
      automaticSilentRenew: true,
      silent_redirect_uri: 'http://localhost:4200/silent-refresh.html'
  };
}
