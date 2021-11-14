using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.Implementacion.Vehiculo;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Mapeadores.Vehiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Implementacion.Vehiculo
{
    public class ImplVehiculoLogica
    {
        private ImplVehiculoDatos accesoDatos;

        public ImplVehiculoLogica()
        {
            this.accesoDatos = new ImplVehiculoDatos();
        }

        public IEnumerable<VehiculoDTO> ListarRegistros(String filtro,
                                                     int numPagina,
                                                     int registroPorPagina,
                                                     out int totalRegistro)
        {
            var listado = this.accesoDatos.ListarRegistros(filtro, numPagina
                , registroPorPagina, out totalRegistro);
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            return mapeador.MapearTipo1Tipo2(listado);

        }


        public VehiculoDTO BuscarRegistro(int id)
        {
            var registro = this.accesoDatos.BuscarRegistro(id);
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            return mapeador.MapearTipo1Tipo2(registro);
        }

        public Boolean GuardarRegistro(VehiculoDTO registro)
        {
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            VehiculoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.GuardarRegistro(reg);
            return res;
        }

        public Boolean EditarRegistro(VehiculoDTO registro)
        {
            MapeadorVehiculoLogica mapeador = new MapeadorVehiculoLogica();
            VehiculoDbModel reg = mapeador.MapearTipo2Tipo1(registro);
            Boolean res = this.accesoDatos.EditarRegistro(reg);
            return res;
        }

        public Boolean EliminarRegistro(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistro(id);
            return res;
        }

        public Boolean EliminarRegistroFoto(int id)
        {
            Boolean res = this.accesoDatos.EliminarRegistroFoto(id);
            return res;
        }


        public Boolean GuardarNombreFoto(FotoVehiculoDTO dto)
        {
            MapeadorFotoVehiculoLogica mapeador = new MapeadorFotoVehiculoLogica();
            FotoVehiculoDbModel dbModel = mapeador.MapearTipo2Tipo1(dto);
            bool res = this.accesoDatos.GuardarFotoVehiculo(dbModel);
            return res;

        }

        public IEnumerable <FotoVehiculoDTO> ListaFotosVehiculoPorId(int idVehiculo)
        {
            IEnumerable<FotoVehiculoDbModel> listaDBModel =
                                             this.accesoDatos.ListarFotosVehiculoPorId(idVehiculo);
            MapeadorFotoVehiculoLogica mapeador = new MapeadorFotoVehiculoLogica();
            IEnumerable<FotoVehiculoDTO> lista = mapeador.MapearTipo1Tipo2(listaDBModel);
            return lista;
            
        }
    }
}
