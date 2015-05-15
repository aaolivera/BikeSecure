using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interfaz;

namespace Dominio
{
    public class Zocalo : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual List<Estado> EstadosHistoricos { get; set; }
    }
}
