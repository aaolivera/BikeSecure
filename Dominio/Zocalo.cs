using System.ComponentModel.DataAnnotations;
using Interfaz;

namespace Dominio
{
    public class Zocalo : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string NumeroDeTarjeta { get; set; }
    }
}
