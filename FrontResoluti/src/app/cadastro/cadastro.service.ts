import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, map, tap } from 'rxjs';
import { IUserCadastro, IUserEdit } from '../Interfaces/IUsuario';

@Injectable({
  providedIn: 'root'
})
export class CadastroService {


  private apiUrl = 'https://localhost:7200';

  constructor(private http: HttpClient,
    private router: Router) { }


  cadastrarUser(usuario: IUserCadastro){
    return this.http.post<IUserCadastro>(`${this.apiUrl}/cadastro`, usuario)
    .pipe(map((res: any) => {
      return res;
    }))
  }


  editarUsuario(pessoaId: number, usuario: IUserEdit){

    console.log(usuario)
    const token = localStorage.getItem('tokenResoluti');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });


    return this.http.put<any>(`${this.apiUrl}/PessoaFisica/${pessoaId}`,
     usuario,
    {headers})


  }

  getAll(){
    return this.http.get<any[]>(`${this.apiUrl}/PessoaFisica`)
  }

  getById(pessoaId: number){

    const token = localStorage.getItem('tokenResoluti');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });

    return this.http.get<any>(`${this.apiUrl}/PessoaFisica/${pessoaId}`, {headers})
    .pipe(map((res: any) => {
      return res;
    }))
  }

  Excluir(pessoaId: number){

    const token = localStorage.getItem('tokenResoluti');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });

    return this.http.delete<any>(`${this.apiUrl}/PessoaFisica/${pessoaId}`, {headers})
    .pipe(map((res: any) => {
      return res;
    }))
  }
}
