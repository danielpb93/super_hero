import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface Heroi {
  id: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento: Date;
  altura: number;
  peso: number;
  superpoderes: Superpoderes[];
}

export interface Superpoderes {
  id: number;
  nome: string;
  descricao: string;
}

@Injectable({
  providedIn: 'root',
})
export class SuperHeroService {
  constructor(private http: HttpClient) {}

  get() {
    return this.http.get<Heroi[]>(`${environment.apiUrl}/heroi`);
  }
}
