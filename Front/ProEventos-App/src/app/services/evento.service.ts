import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable(
  //{ providedIn: 'root'}
)
export class EventoService {
  private baseURL = 'https://localhost:5001/api/Evento';

  constructor(private http: HttpClient) { }

  public ObterTodosEventos(): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/ObterTodos`);
  }

  public ObterEventosPorTema(tema: string): Observable<Evento[]>{
    return this.http.get<Evento[]>(`${this.baseURL}/ObterPorTema/${tema}`);
  }

  public ObterEventoPorId(id: number): Observable<Evento>{
    return this.http.get<Evento>(`${this.baseURL}/ObterPorId/${id}`);
  }

}
