using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Mapeadores.Parametros
{
    public class MapeadorProveedorDatos: MapeadorBaseDatos<tb_proveedor,ProveedorDbModel>
    {
        public override ProveedorDbModel MapearTipo1Tipo2(tb_proveedor entrada)
        {
            return new ProveedorDbModel()
            {
                Id = entrada.id,
                Razon_Social = entrada.razon_social,
                Correo = entrada.correo,
                Direccion = entrada.direccion,
                Telefono = entrada.telefono
            };
        }

        public override IEnumerable<ProveedorDbModel> MapearTipo1Tipo2(IEnumerable<tb_proveedor> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_proveedor MapearTipo2Tipo1(ProveedorDbModel entrada)
        {
            return new tb_proveedor()
            { 
                id = entrada.Id,
                razon_social = entrada.Razon_Social,
                correo = entrada.Correo,
                direccion = entrada.Direccion,
                telefono = entrada.Telefono
            };
        }

        public override IEnumerable<tb_proveedor> MapearTipo2Tipo1(IEnumerable<ProveedorDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}
