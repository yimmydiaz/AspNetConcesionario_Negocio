using ASPConcesionario.Models.Vehiculos;
using LogicaNegocio.DTO.Vehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Mapeadores.Vehiculo
{
    public class MapeadorFotoVehiculoGUI:  MapeadorBaseGUI<FotoVehiculoDTO, ModeloFotoVehiculo>
    {
        public override ModeloFotoVehiculo MapearTipo1Tipo2(FotoVehiculoDTO entrada)
        {
            return new ModeloFotoVehiculo()
            {
                Id = entrada.Id,
                IdVehiculo = entrada.IdVehiculo,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<ModeloFotoVehiculo> MapearTipo1Tipo2(IEnumerable<FotoVehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override FotoVehiculoDTO MapearTipo2Tipo1(ModeloFotoVehiculo entrada)
        {
            return new FotoVehiculoDTO()
            {
                Id = entrada.Id,
                IdVehiculo = entrada.IdVehiculo,
                NombreFoto = entrada.NombreFoto
            };
        }

        public override IEnumerable<FotoVehiculoDTO> MapearTipo2Tipo1(IEnumerable<ModeloFotoVehiculo> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}