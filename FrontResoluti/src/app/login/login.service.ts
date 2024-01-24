import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, tap } from 'rxjs';
import { Usuario } from './usuario';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private apiUrl = 'https://localhost:7200';
  constructor(private http: HttpClient,
    private router: Router) { }


  login(credentials: Usuario) {

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    })

    const options = headers;

    return this.http.post<any>(`${this.apiUrl}/Login`, JSON.stringify(credentials), {headers})
    .pipe(map((res: any) => {

      const token = res?.token;
      if (token) {
        localStorage.setItem('tokenResoluti', token);
      }
      return res;
    }))

  }


}
