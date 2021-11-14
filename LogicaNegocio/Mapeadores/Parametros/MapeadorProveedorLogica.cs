using AccesoDeDatos.DbModel.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Mapeadores.Parametros
{
    public class MapeadorProveedorLogica : MapeadorBaseLogica<ProveedorDbModel, ProveedorDTO>
    {
        public override ProveedorDTO MapearTipo1Tipo2(ProveedorDbModel entrada)
        {
            return new ProveedorDTO()
            {
                Id = entrada.Id,
                Razon_Social = entrada.Razon_Social,
                Correo = entrada.Correo,
                Direccion = entrada.Direccion,
                Telefono = entrada.Telefono
            };
        }

        public override IEnumerable<ProveedorDTO> MapearTipo1Tipo2(IEnumerable<ProveedorDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProveedorDbModel MapearTipo2Tipo1(ProveedorDTO entrada)
        {
            return new ProveedorDbModel()
            {
                Id = entrada.Id,
                Razon_Social = entrada.Razon_Social,
                Correo = entrada.Correo,
                Direccion = entrada.Direccion,
                Telefono = entrada.Telefono
            };
        }

        public override IEnumerable<ProveedorDbModel> MapearTipo2Tipo1(IEnumerable<ProveedorDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }

    }
}
