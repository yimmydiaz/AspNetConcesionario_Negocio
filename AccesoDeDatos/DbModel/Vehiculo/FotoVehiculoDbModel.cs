﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.DbModel.Vehiculo
{
    public class FotoVehiculoDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int idVehiculo;

        public int IdVehiculo
        {
            get { return idVehiculo; }
            set { idVehiculo = value; }
        }

        private string nombreFoto;

        public string NombreFoto
        {
            get { return nombreFoto; }
            set { nombreFoto = value; }
        }

    }
}
