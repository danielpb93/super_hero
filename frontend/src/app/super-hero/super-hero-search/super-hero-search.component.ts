import { SuperHeroService } from './../super-hero.service';
import { Component, OnInit } from '@angular/core';
import { catchError, ignoreElements, Observable, of } from 'rxjs';
import { Heroi } from '../super-hero.service';

@Component({
  selector: 'app-super-hero-search',
  templateUrl: './super-hero-search.component.html',
  styleUrls: ['./super-hero-search.component.scss'],
})
export class SuperHeroSearchComponent implements OnInit {
  heroi$!: Observable<Heroi>;
  heroiError$!: Observable<any>;

  constructor(private superHeroService: SuperHeroService) {}

  ngOnInit(): void {}

  getHeroById(id: number) {
    this.heroi$ = this.superHeroService.getHeroById(id);
    this.heroiError$ = this.heroi$.pipe(
      ignoreElements(),
      catchError((err) => of(err))
    );
  }
}
