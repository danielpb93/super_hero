import { SuperHeroService, Heroi } from './../super-hero.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-super-hero-list',
  templateUrl: './super-hero-list.component.html',
  styleUrls: ['./super-hero-list.component.scss'],
})
export class SuperHeroListComponent implements OnInit {
  superHeroes$!: Observable<Heroi[]>;
  constructor(private superHeroService: SuperHeroService) {}

  ngOnInit(): void {
    this.superHeroes$ = this.superHeroService.get();
  }
}
