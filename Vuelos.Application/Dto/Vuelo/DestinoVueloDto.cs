﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuelos.Application.Dto.Vuelo
{
    public class DestinoVueloDto
    {
        public Guid Id { get; set; }
        public string DepartamentoOrigen { get; set; }
        public Guid IdAeropuertoOrigen { get; set; }
        public string NombreAeropuertoOrigen { get; set; }
        public string DepartamentoDestino { get; set; }
        public Guid IdAeropuertoDestino { get; set; }
        public string NombreAeropuertoDestino { get; set; }
    }
}
