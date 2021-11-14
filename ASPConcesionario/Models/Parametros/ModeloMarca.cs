﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Models.Parametros
{
    public class ModeloMarca
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        [Required]
        [MinLength(3)]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


    }
}