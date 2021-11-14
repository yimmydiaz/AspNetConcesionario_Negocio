using AccesoDeDatos.DbModel.Parametros;
using AccesoDeDatos.Implementacion.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Mapeadores.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Parametros
{
    public class ImplProveedorLogica
    {
        private ImplProveedorDatos accesoDatos;

        public ImplProveedorLogica()
        {
            this.accesoDatos = new ImplProveedorDatos();
        }

        public IEnumerable<ProveedorDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorProveedorLogica mapeador = new MapeadorProveedorLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }
        public ProveedorDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorProveedorLogica mapeador = new MapeadorProveedorLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(ProveedorDTO registro)
        {
            MapeadorProveedorLogica mapeador = new MapeadorProveedorLogica();
            ProveedorDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(ProveedorDTO registro)
        {
            MapeadorProveedorLogica mapeador = new MapeadorProveedorLogica();
            ProveedorDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }
    }
}
