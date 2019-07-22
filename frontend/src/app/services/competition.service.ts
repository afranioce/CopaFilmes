import { CompetitionCompleted } from './../models/competition-completed';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { NewCompetition } from '../models/new-competition';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompetitionService {
  constructor(protected http: HttpClient) { }

  create(newCompetition: NewCompetition): Observable<CompetitionCompleted> {
    return this.http.post<CompetitionCompleted>(`${environment.baseUrl}/competitions`, newCompetition);
  }
}
