using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Vehiculo
{
    public class MapeadorVehiculoDatos: MapeadorBaseDatos<tb_vehiculo, VehiculoDbModel>
    {
        public override VehiculoDbModel MapearTipo1Tipo2(tb_vehiculo entrada)
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
                serie_motor = entrada.serie_motor,
                nombreCategoria = entrada.tb_categoria.nombre,
                nombreMarca = entrada.tb_marca.nombre,
                razonSocialProveedor = entrada.tb_proveedor.razon_social
            };
        }

        public override IEnumerable<VehiculoDbModel> MapearTipo1Tipo2(IEnumerable<tb_vehiculo> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_vehiculo MapearTipo2Tipo1(VehiculoDbModel entrada)
        {
            return new tb_vehiculo()
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

        public override IEnumerable<tb_vehiculo> MapearTipo2Tipo1(IEnumerable<VehiculoDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }

    }
}
