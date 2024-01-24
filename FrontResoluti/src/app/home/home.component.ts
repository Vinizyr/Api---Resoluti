import { CadastroService } from './../cadastro/cadastro.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faTrash } from '@fortawesome/free-solid-svg-icons'
import { faEdit } from '@fortawesome/free-solid-svg-icons'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { formatDate } from '@angular/common';
import { IUserEdit } from '../Interfaces/IUsuario';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  usuarioEdit: any
  pessoaId: number
  formEdit: FormGroup
  faTrash = faTrash;
  faEdit = faEdit
  abrirModal: boolean = false;
  pessoasList: any[]
  constructor(private router: Router,
    private cadastroService: CadastroService,
    private formBuilder: FormBuilder) {

    this.formEdit = formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      sobrenome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(30)]],
      rg: ['', Validators.required],
      cpf: ['', Validators.pattern(/^\d{3}\.\d{3}\.\d{3}-\d{2}$/)],
      dataNascimento: [null, Validators.required]
    })

  }
  ngOnInit() {
    this.getPessoas();
  }

  abrirModalEditar(usuario: IUserEdit){
    this.usuarioEdit = usuario
    this.pessoaId = usuario.pessoaId
    console.log(this.usuarioEdit.dataNascimento)

    const dataNasc = this.usuarioEdit.dataNascimento;

    const dataNascimentoOk = new Date(dataNasc);


    this.formEdit.controls['nome'].setValue(this.usuarioEdit.nome);
    this.formEdit.controls['sobrenome'].setValue(this.usuarioEdit.sobreNome);
    this.formEdit.controls['rg'].setValue(this.usuarioEdit.rg);
    this.formEdit.controls['cpf'].setValue(this.usuarioEdit.cpf);
    this.formEdit.controls['dataNascimento'].setValue(formatDate(dataNascimentoOk, 'dd-MM-yyy', 'en'));


    this.formEdit.updateValueAndValidity();
    this.abrirModal = true;
  }

  fecharModal(){
    this.abrirModal = false;
  }

  logout(){
    localStorage.removeItem('tokenResoluti');
    this.router.navigateByUrl('/login');
  }

  getPessoas(){

    this.cadastroService.getAll().subscribe((res => {
      this.pessoasList = res
    }));
  }

  EditarUsuario(){
    console.log(this.formEdit.value)
    this.cadastroService.editarUsuario(this.pessoaId, this.formEdit.value).subscribe(data => {
      if(data.sucesso){
        alert(data.mensagem)
      }
    })
  }

  deletar(pessoaId: number){

    this.cadastroService.Excluir(pessoaId).subscribe(x => {
      if(x.sucesso){
        alert(x.mensagem);
        this.getPessoas();
      }
      alert(x.mensagem)

    })
  }
}
