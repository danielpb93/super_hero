import { SuperHeroService } from './../super-hero.service';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Superpoder } from '../super-hero.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { MessageService } from 'primeng/api';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-super-hero-form',
  templateUrl: './super-hero-form.component.html',
  styleUrls: ['./super-hero-form.component.scss'],
})
export class SuperHeroFormComponent implements OnInit {
  superpoderes$!: Observable<Superpoder[]>;
  heroiForm: FormGroup = this.fb.group({
    nome: [null, Validators.required],
    nomeHeroi: [null, Validators.required],
    dataNascimento: [null, Validators.required],
    peso: [null, Validators.required],
    altura: [null, Validators.required],
    superpoderes: [null, Validators.required],
  });
  constructor(
    private superHeroService: SuperHeroService,
    private ref: DynamicDialogRef,
    private fb: FormBuilder,
    private config: DynamicDialogConfig,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.superpoderes$ = this.superHeroService.getSuperpowers();
    if (this.config.data) {
      this.superHeroService.getHeroById(this.config.data).subscribe((data) =>
        this.heroiForm.patchValue({
          ...data,
          dataNascimento: formatDate(
            data.dataNascimento,
            'yyyy-MM-dd',
            'en-US'
          ),
          superpoderes: data.superpoderes.map((sp) => sp.id),
        })
      );
    }
  }

  onSubmit() {
    if (this.config.data) {
      this.updateHero();
    } else {
      this.createHero();
    }
  }

  closeModal() {
    this.ref.close();
  }

  updateHero() {
    this.superHeroService
      .updateHero(this.config.data, this.heroiForm.value)
      .subscribe({
        next: (response) => {
          this.messageService.add({
            severity: 'success',
            summary: 'Heroi atualizado com sucesso!',
            life: 4000,
          });

          this.ref.close();
        },
        error: (err) => {
          this.messageService.add({
            severity: 'error',
            summary: 'Erro ao atualizar Heroi',
            detail: `${err.message}`,
            life: 4000,
          });
        },
      });
  }

  createHero() {
    this.superHeroService.createHero(this.heroiForm.value).subscribe({
      next: (response) => {
        this.messageService.add({
          severity: 'success',
          summary: 'Heroi criado com sucesso!',
          life: 4000,
        });

        this.ref.close();
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Erro ao criar Heroi',
          detail: `${err.message}`,
          life: 4000,
        });
      },
    });
  }
}
