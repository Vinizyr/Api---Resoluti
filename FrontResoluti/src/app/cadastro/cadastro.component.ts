import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LoginService } from '../login/login.service';
import { CadastroService } from './cadastro.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {
  public formCadastro: FormGroup

  constructor(private formBuilder: FormBuilder,
    private cadastroService: CadastroService,
    ){
    this.formCadastro = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      sobrenome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      dataNascimento: ['', Validators.required],
      rg: ['', Validators.required],
      cpf: ['', Validators.pattern(/^\d{3}\.\d{3}\.\d{3}-\d{2}$/)],
      estado: ['', [Validators.minLength(2), Validators.maxLength(30)]],
      cidade: ['', [Validators.minLength(3), Validators.maxLength(30)]],
      cep: [null, Validators.required],
      logradouro: ['', [Validators.minLength(3), Validators.maxLength(30)]],
      complemento: ['', [Validators.minLength(3), Validators.maxLength(30)]],
      numero: [null, Validators.required],
      email: ['',  Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)],
      telefoneCelular: ['', Validators.pattern(/^\([1-9]{2}\) 9[6-9][0-9]{3}\-[0-9]{4}$/)],
      username: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30)]],
      senha: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]]
    })
  }

  enviarDados(){
    this.cadastroService.cadastrarUser(this.formCadastro.value).subscribe(data => {
      if(data.sucesso){
        alert(data.mensagem)
        this.formCadastro.reset()
      }else{
        alert(data.mensagem)
      }
    });
  }
}
