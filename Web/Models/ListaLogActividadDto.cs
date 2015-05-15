using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio;

namespace Web.Models
{
    public class ListaLogActividadDto
    {
        public string Titulo { get; set; }
        public virtual Estado EstadoActual { get; set; }
        public virtual List<Estado> Estados { get; set; }
    }
}