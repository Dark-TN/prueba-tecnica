import { TestBed } from '@angular/core/testing';

import { MensajeDatosContactoService } from './mensaje-datos-contacto.service';

describe('MensajeDatosContactoService', () => {
  let service: MensajeDatosContactoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MensajeDatosContactoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
