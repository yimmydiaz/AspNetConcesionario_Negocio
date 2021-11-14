using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Parametros
{
    public class ProveedorDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string razon_Social;


        public string Razon_Social
        {
            get { return razon_Social; }
            set { razon_Social = value; }
        }

        public string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string correo;

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
    }
}
