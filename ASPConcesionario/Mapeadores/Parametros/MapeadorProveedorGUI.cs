using ASPConcesionario.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPConcesionario.Mapeadores.Parametros
{
    public class MapeadorProveedorGUI : MapeadorBaseGUI<ProveedorDTO, ModeloProveedor>
    {
        public override ModeloProveedor MapearTipo1Tipo2(ProveedorDTO entrada)
        {
            return new ModeloProveedor()
            {
                Id = entrada.Id,
                Razon_Social = entrada.Razon_Social,
                Correo = entrada.Correo,
                Direccion = entrada.Direccion,
                Telefono = entrada.Telefono
            };
        }

        public override IEnumerable<ModeloProveedor> MapearTipo1Tipo2(IEnumerable<ProveedorDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override ProveedorDTO MapearTipo2Tipo1(ModeloProveedor entrada)
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

        public override IEnumerable<ProveedorDTO> MapearTipo2Tipo1(IEnumerable<ModeloProveedor> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}