import { Component, OnInit } from '@angular/core';
import { FormGroup, FormArray, FormControl } from '@angular/forms';
import { MovieService } from '../../services/movie.service';
import { Movie } from '../../models/movie';
import { CompetitionService } from 'src/app/services/competition.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  title: string = "Fase da Seleção";
  description: string = "Selecione 8 filmes que você deseja que entrem na competição e depois pressione o botão \"Gerar Meu Campeonato\" para prosseguir.";

  movies: Movie[] = [];
  selecteds: number = 0;
  competitionFormGroup = new FormGroup({
    playerIds: new FormArray([])
  });

  constructor(
    private movieService: MovieService,
    private competitionService: CompetitionService,
    private router: Router) { }

  ngOnInit() {
    this.movieService.getAll().subscribe(movies => this.movies = movies);
  }

  updateCheckboxes(id: string, isChecked: boolean) {
    const form = this.competitionFormGroup.get('playerIds') as FormArray;
    if (isChecked) {
      form.push(new FormControl(id));
      ++this.selecteds;
    } else {
      let idx = form.controls.findIndex(x => x.value == id);
      form.removeAt(idx);
      --this.selecteds;
    }
  }

  submit() {
    this.competitionService
      .create(this.competitionFormGroup.value.playerIds)
      .subscribe(result => this.router.navigate(['/results', result]));
  }
}
