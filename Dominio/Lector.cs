using System.ComponentModel.DataAnnotations;
using Interfaz;

namespace Dominio
{
    public class Lector : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
    }
}
