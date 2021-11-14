using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Models.Parametros
{
    public class ModeloProveedor
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string razon_Social;

        [Required]
        [MinLength(8)]
        public string Razon_Social
        {
            get { return razon_Social; }
            set { razon_Social = value; }
        }

        public string direccion;
        [Required]
        [MinLength(5)]
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string telefono;
        [Required]
        [MinLength(10)]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string correo;
        [Required]
        [MinLength(5)]
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }
    }
}