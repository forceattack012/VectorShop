import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthenService } from 'src/app/core/authentication/authen.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formLogin: FormGroup;

  constructor(private formBuilder: FormBuilder, private authenService: AuthenService) {
    this.formLogin = this.formBuilder.group({
      userName : ['', [Validators.required]],
      password: ['', [Validators.required, Validators.pattern('[-_a-zA-Z0-9]*')]]
    });
   }

  ngOnInit(): void {
    this.setFormLogin();
  }

  setFormLogin(): void {
    this.formLogin = this.formBuilder.group({
      userName : ['', [Validators.required]],
      password: ['', [Validators.required, Validators.pattern('[-_a-zA-Z0-9]*')]]
    });
  }

  get userName(): any {
    return this.formLogin?.get('userName');
  }

  get password(): any {
    return this.formLogin?.get('password');
  }

  login(): void {
    if (this.formLogin?.valid) {
      this.authenService.login(this.formLogin.value);
    }
  }
}
