using AccesoDeDatos.DbModel.Vehiculo;
using LogicaNegocio.DTO.Vehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Vehiculo
{
    public class MapeadorVehiculoLogica: MapeadorBaseLogica<VehiculoDbModel, VehiculoDTO>
    {
        public override VehiculoDTO MapearTipo1Tipo2(VehiculoDbModel entrada)
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
                serie_motor = entrada.serie_motor,
                nombreCategoria = entrada.nombreCategoria,
                nombreMarca = entrada.nombreMarca,
                razonSocialProveedor = entrada.razonSocialProveedor
            };
        }

        public override IEnumerable<VehiculoDTO> MapearTipo1Tipo2(IEnumerable<VehiculoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override VehiculoDbModel MapearTipo2Tipo1(VehiculoDTO entrada)
        {
            return new VehiculoDbModel()
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

        public override IEnumerable<VehiculoDbModel> MapearTipo2Tipo1(IEnumerable<VehiculoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
