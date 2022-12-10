import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CatalogosService {

  constructor(private http: HttpClient) { }

  getCatalogoCiudadEstadoPorNombre(nombre:string):Observable<string[]>{
    return this.http.get<string[]>("https://localhost:7037/api/Catalogos/CatalogoCiudadEstado/" + nombre);
  }
}
