﻿using System;
using System.ComponentModel.DataAnnotations;
using Interfaz;

namespace Dominio
{
    public class LogActividad : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string NumeroDeTarjeta { get; set; }
        public virtual Zocalo Zocalo { get; set; }
        public virtual DateTime Fecha { get; set; }
    }
}
