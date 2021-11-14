using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Vehiculo
{
    public class VehiculoDbModel
    {
        public int id { get; set; }
        public string color { get; set; }
        public int modelo { get; set; }
        public string serie_chasis { get; set; }
        public string serie_motor { get; set; }
        public int id_marca { get; set; }
        public int id_categoria { get; set; }
        public int precio { get; set; }
        public int descuento { get; set; }
        public bool estado { get; set; }
        public int id_proveedor { get; set; }
        public string nombreCategoria { get; set; }
        public string nombreMarca { get; set; }
        public string razonSocialProveedor { get; set; }
    }
}
