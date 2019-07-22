import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Movie } from '../models/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  constructor(protected http: HttpClient) { }

  getAll() {
    return this.http.get<Movie[]>(`${environment.baseUrl}/movies`);
  }

  get(id: string) {
    return this.http.get<Movie>(`${environment.baseUrl}/movies/${id}`);
  }
}
