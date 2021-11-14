using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Models.Vehiculos
{
    public class ModeloVehiculo
    {
        public int id { get; set; }

        [Required]
        [DisplayName("Color")]
        public string color { get; set; }
        public int modelo { get; set; }

        [Required]
        [DisplayName("Serie del Motor")]
        public string serie_chasis { get; set; }

        [Required]
        [DisplayName("Serie del Motor")]
        public string serie_motor { get; set; }

      
        public int id_marca { get; set; }

       
        public int id_categoria { get; set; }
        
        [Required]
        public int precio { get; set; }

        [Required]
        public int descuento { get; set; }

        [Required]
        public bool estado { get; set; }

        [Required]
        [DisplayName("Proveedor")]
        public int id_proveedor { get; set; }

        [DisplayName("Categoria")]
        public string nombreCategoria { get; set; }

        [DisplayName("Marca")]
        public string nombreMarca { get; set; }

        [DisplayName("Proveedor")]
        public string razonSocialProveedor { get; set; }


    }
}