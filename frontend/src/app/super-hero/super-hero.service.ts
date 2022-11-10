import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface HeroiDto {
  nome: string;
  nomeHeroi: string;
  dataNascimento: Date;
  altura: number;
  peso: number;
  superpoderesIds: number[];
}

export interface Heroi {
  id: number;
  nome: string;
  nomeHeroi: string;
  dataNascimento: Date;
  altura: number;
  peso: number;
  superpoderes: Superpoder[];
}

export interface Superpoder {
  id: number;
  nome: string;
  descricao: string;
}

@Injectable({
  providedIn: 'root',
})
export class SuperHeroService {
  constructor(private http: HttpClient) {}

  getHeroes() {
    return this.http.get<Heroi[]>(`${environment.apiUrl}/heroi`);
  }

  getHeroById(id: number) {
    return this.http.get<Heroi>(`${environment.apiUrl}/heroi/${id}`);
  }

  getSuperpowers() {
    return this.http.get<Superpoder[]>(`${environment.apiUrl}/superpoder`);
  }

  createHero(heroi: HeroiDto) {
    return this.http.post<Heroi>(`${environment.apiUrl}/heroi`, heroi);
  }

  updateHero(id: number, heroi: HeroiDto) {
    return this.http.put(`${environment.apiUrl}/heroi/${id}`, heroi);
  }

  deleteHero(id: number) {
    return this.http.delete(`${environment.apiUrl}/heroi/${id}`);
  }
}
