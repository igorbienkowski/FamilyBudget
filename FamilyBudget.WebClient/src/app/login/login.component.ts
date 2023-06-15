import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  username: string = 'Igor';
  password: string = 'stringA1!';
  readonly apiUrl = environment.apiUrl + '/Api/Users/Login';

  constructor(private http: HttpClient, private authService: AuthService) { }

  onLogin() {
    this.http.post<any>(this.apiUrl, {username: this.username, password: this.password})
      .subscribe(response => {
        this.authService.setToken(response.token);
        console.log(response.token)
        console.log(this.authService.getToken())
      }, error => {
        console.log(error);
      });
  }
}
