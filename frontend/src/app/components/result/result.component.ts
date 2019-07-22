import { MovieService } from './../../services/movie.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { concatMap, mergeMap } from 'rxjs/operators';
import { Movie } from '../../models/movie';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.scss']
})
export class ResultComponent implements OnInit {
  title = 'Resultado Final';
  description = 'Veja o Resultado final do campeonato de filmes de forma simples e rápida.';
  movies: Movie[] = [];

  constructor(private route: ActivatedRoute, private movieService: MovieService) { }

  ngOnInit() {
    this.route.params
      .pipe(
        concatMap(params => params.ids.split(',')),
        mergeMap((id: string) => this.movieService.get(id))
      )
      .subscribe(movie => this.movies.push(movie));
  }
}
