import { Component, Inject, OnInit } from '@angular/core';
import { CatalogosService } from './services/catalogos.service';
import {FormControl} from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import { DatePipe } from '@angular/common'
import {MatDialog, MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import { DialogData } from './interfaces/dialog-data';
import { DatosContacto } from './interfaces/datos-contacto';
import { MensajeDatosContactoService } from './services/mensaje-datos-contacto.service';
import { ignoreElements } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PruebaTecnicaEctotecAngular';
  autocompleteControl = new FormControl('');
  filteredOptions: string[] = [];
  nombre: string = '';
  correoElectronico: string = '';
  telefono: string = '';
  fecha: string = '';
  ciudadEstado: string = '';
  minDate: Date;
  maxDate: Date;
  errores: string[] = [];
  datosContacto: DatosContacto;
  captcha:string = '';

  constructor(private _servicioCatalogos : CatalogosService, private _servicioMensajeDatosContacto: MensajeDatosContactoService, private _dialog: MatDialog, private _datepipe: DatePipe){
    const currentYear = new Date().getFullYear();
    this.minDate = new Date(currentYear - 100, 0, 1);
    this.maxDate = new Date(currentYear, 11, 31);

  }

  ngOnInit():void{
    this.autocompleteControl.valueChanges
    .subscribe(value => {
      if(value!.length >= 3){
        this._servicioCatalogos.getCatalogoCiudadEstadoPorNombre(value!).subscribe(response => {
          this.filteredOptions = response;
        });
      }
      else{
        this.filteredOptions = [];
      }
    });
  }

  selectOption(e: MatAutocompleteSelectedEvent) {
    this.ciudadEstado = e.option.value;
    console.log(this.ciudadEstado);
 }

 addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.fecha = this._datepipe.transform(event.value, 'dd/MM/yyyy')!;
    console.log(this.fecha);
  }

  openDialog() {
    this._dialog.open(DialogError, {data: {errores:this.errores}});
  }

  onSubmit(): void{
    this.errores = [];

    const regexCorreo = /^[a-zA-Z0-9\._-]+@[a-zA-Z0-9\.-]+(\.[a-zA-Z]{2,6})+$/;
    const regexTelefono = /^\+?\#? *\(?\d{3}\)?-? *\d{3}-? *-?\d{4}/;
    if(this.nombre == '' || this.correoElectronico == '' || this.telefono == '' || this.fecha == '' || this.ciudadEstado == ''){
      this.errores.push('Faltan datos')
    }
    if(this.fecha != ''){
      let year = +this.fecha.slice(-4); 
      if(year > new Date().getFullYear() || year < new Date().getFullYear() - 100){
        this.errores.push('La fecha no es válida')
    }
    if(this.captcha == ''){
      this.errores.push('Captcha sin resolver')
    }
    }
    if(!regexCorreo.test(this.correoElectronico)){
      this.errores.push('El correo electrónico no es válido')
    }
    if(!regexTelefono.test(this.telefono)){
      this.errores.push('El teléfono no es válido')
    }
    if(this.errores.length > 0){
      this.openDialog();
    }
    else{
      console.log(this.nombre, this.correoElectronico, this.telefono, this.fecha, this.ciudadEstado);
      this.datosContacto = {
        nombre: this.nombre,
        correoElectronico: this.correoElectronico,
        telefono: this.telefono,
        fecha: this.fecha,
        ciudadEstado: this.ciudadEstado
      };
      this._servicioMensajeDatosContacto.postMensajeDatosContacto(this.datosContacto);
      alert('Mensaje enviado');
      this.nombre = '';
      this.correoElectronico = '';
      this.telefono = '';
      this.fecha = '';
      this.ciudadEstado = '';
    }
  }

  resolved(captchaResponse: string) {
    this.captcha = captchaResponse;
    console.log('resolved captcha with response: ' + this.captcha);
}

}

@Component({
  selector: 'dialog-error',
  templateUrl: 'dialog-error.html',
})
export class DialogError {
  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData) {
    console.log(data.errores);
  }
}
