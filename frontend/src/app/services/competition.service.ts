import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movie } from '../models/movie';
import { environment } from '../../environments/environment';
import { NewCompetition } from '../models/new-competition';

@Injectable({
  providedIn: 'root'
})
export class CompetitionService {
  constructor(protected http: HttpClient) { }

  create(newCompetition: NewCompetition) {
    return this.http.post<Movie[]>(`${environment.baseUrl}/movies`, newCompetition);
  }
}
