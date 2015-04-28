using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Interfaz;

namespace Dominio
{
    public class Bicicletero : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual Lector Lector { get; set; }
        public virtual List<Zocalo> Zocalos { get; set; }
    }
}
