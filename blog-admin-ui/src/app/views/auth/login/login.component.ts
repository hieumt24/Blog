import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AdminApiAuthApiClient, AuthenticatedResult, LoginRequest } from 'src/app/api/admin-api.service.generated';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm : FormGroup;

  constructor(private fb : FormBuilder, private authApiClient: AdminApiAuthApiClient) {
    this.loginForm = this.fb.group({
      userName : new FormControl('', Validators.required),
      password : new FormControl('', Validators.required),
   })
  }

  login() {
    var request : LoginRequest = new LoginRequest({
      userName : this.loginForm.controls['userName'].value,
      password : this.loginForm.controls['password'].value
    });

    this.authApiClient.login(request).subscribe({
      next:(res:AuthenticatedResult) => {
          //save token and refresh token to local storage
      },
      error: (error: any) => {
        console.log(error);
      },
    })
  }
}
