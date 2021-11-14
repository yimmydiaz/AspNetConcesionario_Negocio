using ASPConcesionario.Models.Vehiculos;
using LogicaNegocio.DTO.Vehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Mapeadores.Vehiculo
{
    public class MapeadorVehiculoGUI: MapeadorBaseGUI<VehiculoDTO,ModeloVehiculo>
    {
        public override ModeloVehiculo MapearTipo1Tipo2(VehiculoDTO entrada)
        {
            return new ModeloVehiculo()
            {
                id = entrada.id,
                color = entrada.color,
                descuento = entrada.descuento,
                estado = entrada.estado,
                id_categoria = entrada.id_categoria,
                id_marca = entrada.id_marca,
                id_proveedor = entrada.id_proveedor,
                modelo = entrada.modelo,
                precio = entrada.precio,
                serie_chasis = entrada.serie_chasis,
                serie_motor = entrada.serie_motor,
                nombreCategoria = entrada.nombreCategoria,
                nombreMarca = entrada.nombreMarca,
                razonSocialProveedor = entrada.razonSocialProveedor
            };
        }

        public override IEnumerable<ModeloVehiculo> MapearTipo1Tipo2(IEnumerable<VehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override VehiculoDTO MapearTipo2Tipo1(ModeloVehiculo entrada)
        {
            return new VehiculoDTO()
            {
                id = entrada.id,
                color = entrada.color,
                descuento = entrada.descuento,
                estado = entrada.estado,
                id_categoria = entrada.id_categoria,
                id_marca = entrada.id_marca,
                id_proveedor = entrada.id_proveedor,
                modelo = entrada.modelo,
                precio = entrada.precio,
                serie_chasis = entrada.serie_chasis,
                serie_motor = entrada.serie_motor
            };
        }

        public override IEnumerable<VehiculoDTO> MapearTipo2Tipo1(IEnumerable<ModeloVehiculo> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}