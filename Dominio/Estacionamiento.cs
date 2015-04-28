using System.ComponentModel.DataAnnotations;
using Interfaz;

namespace Dominio
{
    public class Estacionamiento : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Direccion  { get; set; }
        public virtual int LocalizacionX { get; set; }
        public virtual int LocalizacionY { get; set; }
        public virtual Bicicletero Bicicletero { get; set; }
    }
}
