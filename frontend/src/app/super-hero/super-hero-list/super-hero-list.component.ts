import { ConfirmationService, MessageService } from 'primeng/api';
import { SuperHeroFormComponent } from './../super-hero-form/super-hero-form.component';
import { SuperHeroService, Heroi } from './../super-hero.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DialogService } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-super-hero-list',
  templateUrl: './super-hero-list.component.html',
  styleUrls: ['./super-hero-list.component.scss'],
  providers: [DialogService],
})
export class SuperHeroListComponent implements OnInit {
  superHeroes$!: Observable<Heroi[]>;
  constructor(
    private superHeroService: SuperHeroService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    this.superHeroes$ = this.superHeroService.getHeroes();
  }

  openEditModal(heroi?: Heroi) {
    const ref = this.dialogService.open(SuperHeroFormComponent, {
      header: heroi ? 'editar heroi' : 'criar heroi',
      width: '70%',
      dismissableMask: true,
      data: heroi?.id,
    });

    ref.onClose.subscribe(
      (_) => (this.superHeroes$ = this.superHeroService.getHeroes())
    );
  }

  refresh() {
    this.superHeroes$ = this.superHeroService.getHeroes();
  }

  deleteHero(heroi: Heroi) {
    this.confirmationService.confirm({
      message: `tem certeza que deseja excluir o heroi ${heroi.nomeHeroi}?`,
      accept: () => {
        this.superHeroService.deleteHero(heroi.id).subscribe({
          next: (response) => {
            this.messageService.add({
              severity: 'success',
              summary: 'Heroi excluido com sucesso!',
              life: 4000,
            });

            this.superHeroes$ = this.superHeroService.getHeroes();
          },
          error: (err) => {
            this.messageService.add({
              severity: 'error',
              summary: 'Erro ao excluir Heroi',
              detail: `${err.message}`,
              life: 4000,
            });
          },
        });
      },
    });
  }
}
