using System.Collections.Generic;
using Dominio;

namespace Web.Models
{
    public class IndexDto
    {
        public virtual List<Estacionamiento> Estacionamientos { get; set; }
    }
}