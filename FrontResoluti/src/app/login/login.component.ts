import { LoginService } from './login.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {


  formulario: FormGroup

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private loginService: LoginService,
    ){
    this.formulario = this.formBuilder.group({
      username: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      senha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]]
    })
  }


  entrar() {
    console.log(this.formulario.value)
    this.loginService.login(this.formulario.value).subscribe(data => {
      const token = data?.token
      console.log(data);

      if(token != null){
        this.router.navigate(['/home']);
      }
    })
  }


}
