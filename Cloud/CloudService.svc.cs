
using System;
using System.Globalization;
using System.Linq;
using Dominio;
using Repositorio;

namespace Cloud
{
    public class CloudService : ICloudService
    {
        public string IncommingRead(string rfidName, string macAddres)
        {
            var context = new DbContexto();
            var repositorio = new RepositorioEf(context);

            var estacionamiento = repositorio.Obtener<Estacionamiento>(x => x.Bicicletero.Lector.Nombre == rfidName);
            if (estacionamiento != null)
            {
                var zocaloUsado = estacionamiento.Bicicletero.Zocalos.FirstOrDefault(x => x.Estado != null && x.Estado.NumeroDeTarjeta == macAddres);
                if (zocaloUsado != null)
                {
                    return "E" + ActualizarEstadoZocalo(zocaloUsado, string.Empty, repositorio);
                }
                var zocaloVacio = estacionamiento.Bicicletero.Zocalos.FirstOrDefault(x => x.Estado == null);
                if (zocaloVacio != null)
                {
                    return "I" + ActualizarEstadoZocalo(zocaloVacio, macAddres, repositorio);
                }
                return "0";
            }
            return "-1";
        }

        private static string ActualizarEstadoZocalo(Zocalo zocalo, string numeroDeTarjeta, IRepositorio repositorio)
        {
            if (String.IsNullOrEmpty(numeroDeTarjeta))
            {
                var estado = zocalo.Estado;
                estado.FechaDeSalida = DateTime.Now;
                zocalo.Estado = null;
                zocalo.EstadosHistoricos.Add(estado);
            }
            else
            {
                zocalo.Estado = new Estado
                    {
                        FechaDeEntrada = DateTime.Now,
                        NumeroDeTarjeta = numeroDeTarjeta,
                    };
            }
            repositorio.GuardarCambios();
            return zocalo.Id.ToString(CultureInfo.InvariantCulture);
        }
    }
}
