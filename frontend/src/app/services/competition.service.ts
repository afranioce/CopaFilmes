import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Movie } from '../models/movie';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompetitionService {
  constructor(protected http: HttpClient) { }

  create(playerIds: string[]) {
    return this.http.post<Movie[]>(`${environment.baseUrl}/competitions`, playerIds);
  }
}
