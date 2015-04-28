
using System;
using System.Globalization;
using System.Linq;
using Dominio;
using Repositorio;

namespace Cloud
{
    public class CloudService : ICloudService
    {
        public string IncommingRead(string number, string macAddres)
        {
            var context = new DbContexto();
            var repositorio = new RepositorioEf(context);

            var estacionamiento = repositorio.Obtener<Estacionamiento>(x => x.Bicicletero.Lector.Nombre == macAddres);
            if (estacionamiento != null)
            {
                var zocaloUsado = estacionamiento.Bicicletero.Zocalos.FirstOrDefault(x => x.NumeroDeTarjeta == number);
                if (zocaloUsado != null)
                {
                    return ActualizarEstadoZocalo(zocaloUsado, string.Empty, repositorio);
                }
                var zocaloVacio = estacionamiento.Bicicletero.Zocalos.FirstOrDefault(x => string.IsNullOrEmpty(x.NumeroDeTarjeta));
                if (zocaloVacio != null)
                {
                    return ActualizarEstadoZocalo(zocaloVacio, number, repositorio);
                }
                return "0";
            }
            return "-1";
        }

        private static string ActualizarEstadoZocalo(Zocalo zocalo, string numeroDeTarjeta, RepositorioEf repositorio)
        {
            zocalo.NumeroDeTarjeta = numeroDeTarjeta;
            repositorio.Agregar(new LogActividad {Fecha = new DateTime(), NumeroDeTarjeta = numeroDeTarjeta, Zocalo = zocalo});
            repositorio.GuardarCambios();
            return zocalo.Id.ToString(CultureInfo.InvariantCulture);
        }
    }
}
