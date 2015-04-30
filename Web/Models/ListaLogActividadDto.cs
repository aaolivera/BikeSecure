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
        public virtual List<LogActividad> LogActividades { get; set; }
    }
}