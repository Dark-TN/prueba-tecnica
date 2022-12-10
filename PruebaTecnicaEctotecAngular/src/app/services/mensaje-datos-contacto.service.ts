import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DatosContacto } from '../interfaces/datos-contacto';

@Injectable({
  providedIn: 'root'
})
export class MensajeDatosContactoService {

  constructor(private http: HttpClient) { }

  postMensajeDatosContacto(datosContacto: DatosContacto):void{
    this.http.post("https://localhost:7037/api/Mensaje/DatosContacto/", datosContacto).subscribe(response => console.log(response));
  }
}
