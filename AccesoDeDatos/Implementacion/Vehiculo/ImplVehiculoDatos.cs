using AccesoDeDatos.DbModel.Vehiculo;
using AccesoDeDatos.Mapeadores.Vehiculo;
using AccesoDeDatos.ModeloDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDeDatos.Implementacion.Vehiculo
{
    public class ImplVehiculoDatos
    {
        /// <summary>
        /// Metodo para listar registros con un filtro
        /// </summary>
        /// <param name="filtro">Filtro a aplicar</param>
        /// <returns>Lista de registros con el filtro aplicado</returns>
        public IEnumerable<VehiculoDbModel> ListarRegistros(string filtro,
                                                     int paginaActual,
                                                     int numRegistroPagina, out int totalRegistro)
        {
            var lista = new List<VehiculoDbModel>();
            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                int reDescartados = (paginaActual - 1) * numRegistroPagina;
                //lista = bd.tb_vehiculo.Where(x => x.nombre.ToUpper()
                //       .Contains(filtro.ToUpper())).Skip(reDescartados).Take(numRegistroPagina).ToList();
                var listaDatos = (from m in bd.tb_vehiculo
                                  where m.serie_chasis.Contains(filtro) || m.serie_motor.Contains(filtro)
                                  select m).ToList();
                totalRegistro = listaDatos.Count();
                listaDatos = listaDatos.OrderBy(m => m.id).Skip(reDescartados).Take(numRegistroPagina).ToList();
                lista = new MapeadorVehiculoDatos().MapearTipo1Tipo2(listaDatos).ToList();
            }
            return lista;
        }

        /// <summary>
        /// Metodo para guardar una marca 
        /// </summary>
        /// <param name="registro">El registro  a almacenar </param>
        /// <returns>True cuando se almaneca y false cuando ya existe un registro igual o una excepcion </returns>
        public bool GuardarRegistro(VehiculoDbModel registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // Verificacion de la existencia de un registro con el mismo nombre
                    if (bd.tb_vehiculo.Where(x => x.serie_chasis.ToLower().Equals(registro.serie_chasis.ToLower())).Count() > 0)
                    {
                        return false;
                    }

                    MapeadorVehiculoDatos mapeadorVehiculo = new MapeadorVehiculoDatos();
                    var regis = mapeadorVehiculo.MapearTipo2Tipo1(registro);
                    bd.tb_vehiculo.Add(regis);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo de busqueda de un registro
        /// </summary>
        /// <param name="id">id del registro buscado</param>
        /// <returns>El objeto con el id buscado o null cuando no exista</returns>
        public VehiculoDbModel BuscarRegistro(int id)
        {

            using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                tb_vehiculo registro = bd.tb_vehiculo.Find(id);
                return new MapeadorVehiculoDatos().MapearTipo1Tipo2(registro);
            }
        }

        /// <summary>
        /// Metodo para editar un registro
        /// </summary>
        /// <param name="registro">el registro a editar</param>
        /// <returns>True cuando se edita y false cuando no existe el registro igual o una excepcion</returns>

        public bool EditarRegistro(VehiculoDbModel registro)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    // Verificacion de la existencia de un registro con el mismo nombre
                    if (bd.tb_vehiculo.Where(x => x.id == registro.id).Count() == 0)
                    {
                        return false;
                    }
                    MapeadorVehiculoDatos mapeadorVehiculo = new MapeadorVehiculoDatos();
                    var regis = mapeadorVehiculo.MapearTipo2Tipo1(registro);
                    bd.Entry(regis).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }



        }



        /// <summary>
        /// Metodo de eliminar un registro
        /// </summary>
        /// <param name="id">id del registro a eliminar</param>
        /// <returns>True cuando se elimina, False cuando no existe o una excepcion</returns>
        public bool EliminarRegistro(int id)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    tb_vehiculo registro = bd.tb_vehiculo.Find(id);
                    if (registro == null || registro.tb_ventas.Count()>0)
                    {
                        return false;
                    }

                    bd.tb_vehiculo.Remove(registro);
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public bool EliminarRegistroFoto(int id)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    tb_fotos registro = bd.tb_fotos.Find(id);
                    if (registro == null)
                    {
                        return false;
                    }
                    registro.estado = false;
                    bd.Entry(registro).State = EntityState.Modified;
                    bd.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }
        public bool GuardarFotoVehiculo(FotoVehiculoDbModel dbModel)
        {
            try
            {
                using (ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
                {
                    if (bd.tb_vehiculo.Where(x => x.id == dbModel.IdVehiculo).Count() > 0)
                    {
                        MapeadorFotoVehiculoDatos mapeador = new MapeadorFotoVehiculoDatos();
                        tb_fotos foto = mapeador.MapearTipo2Tipo1(dbModel);
                        bd.tb_fotos.Add(foto);
                        bd.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
              
            }
            catch(Exception e)
            {
                throw e;
            }
           
        }

        public IEnumerable<FotoVehiculoDbModel> ListarFotosVehiculoPorId(int id)
        {
            using(ConcesionarioBDEntities bd = new ConcesionarioBDEntities())
            {
                //var lista = bd.tb_fotos.Where(x => x.id_vehiculo == id).ToList(); // forma landa
                var lista = (from f in bd.tb_fotos
                              where f.id_vehiculo == id && f.estado
                              select f).ToList(); // de forma linkiu
                MapeadorFotoVehiculoDatos mapeador = new MapeadorFotoVehiculoDatos();
                IEnumerable<FotoVehiculoDbModel> listaDbModel = mapeador.MapearTipo1Tipo2(lista);
                return listaDbModel;

            }
        }
    }
}
