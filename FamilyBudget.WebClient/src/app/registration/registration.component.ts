import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent {
  registrationForm: FormGroup;
  username: string = 'Igor';
  password: string = 'stringA1!';
  email: string = 'test@test.com';
  readonly apiUrl = environment.apiUrl + '/Api/Users/Register';

  constructor(private formBuilder: FormBuilder, private http: HttpClient) {
    this.registrationForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required]
    });
  }

  onRegistration() {
    this.http.post<any>(this.apiUrl, {username: this.username, password: this.password, email: this.email})
      .subscribe(response => {
        console.log(response)
      }, error => {
        console.log(error);
      });
  }
}
