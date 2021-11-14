using ASPConcesionario.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Models.Vehiculos
{
    public class ModeloCargaImagenVehiculo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private HttpPostedFileBase archivo;

        [Required]
        public HttpPostedFileBase Archivo
        {
            get { return archivo; }
            set { archivo = value; }
        }

        private IEnumerable<ModeloFotoVehiculo> listaImagenesVehiculo;

        public IEnumerable<ModeloFotoVehiculo> ListaImagenesVehiculo
        {
            get { return listaImagenesVehiculo; }
            set { listaImagenesVehiculo = value; }
        }

        private String rutaImagenVehiculo = DatosGenerales.RutaMostrarArchivosVehiculos;

        public String RutaImagenVehiculo
        {
            get { return rutaImagenVehiculo; }
        
        }

    }
}