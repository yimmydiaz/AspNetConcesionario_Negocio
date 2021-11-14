using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Helpers
{
    public static class DatosGenerales
    {
        public static int RegistroPorPagina = 
            Int32.Parse(ConfigurationManager.AppSettings["registroPorPagina"].ToString());

        public static String RutaArchivosVehiculos =
          ConfigurationManager.AppSettings["rutaArchivosVehiculo"].ToString();

        public static String RutaMostrarArchivosVehiculos =
          ConfigurationManager.AppSettings["rutaMostrarArchivosVehiculo"].ToString();

        public static String CarpetaFotosVehiculosEliminadas =
        ConfigurationManager.AppSettings["carpetaFotosVehiculoEliminadas"].ToString();
    }
}