using ASPConcesionario.Helpers;
using ASPConcesionario.Mapeadores.Vehiculo;
using ASPConcesionario.Models.Vehiculos;
using LogicaNegocio.DTO.Vehiculo;
using LogicaNegocio.Implementacion.Vehiculo;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ASPConcesionario.Controllers.Vehiculo
{
    public class VehiculoController : Controller
    {
        private ImplVehiculoLogica logica = new ImplVehiculoLogica();

        // GET: Vehiculo
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<VehiculoDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            IEnumerable<ModeloVehiculo> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloVehiculo>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id.Value);
            if (VehiculoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            ModeloVehiculo modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
            return View(modelo);
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloVehiculo modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
                VehiculoDTO VehiculoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(VehiculoDTO);
                return RedirectToAction("Index");
            }
           // ViewBag.OperatorId = new SelectList(modelo.id_marca, "id_Marca");
            return View(modelo);
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id.Value);
            if (VehiculoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            ModeloVehiculo modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
            return View(modelo);
        }

        // POST: Vehiculo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloVehiculo modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
                VehiculoDTO VehiculoDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(VehiculoDTO);

                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id.Value);
            if (VehiculoDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
            ModeloVehiculo modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
            return View(modelo);
        }

        // POST: Vehiculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            bool respuesta = logica.EliminarRegistro(id);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                VehiculoDTO VehiculoDTO = logica.BuscarRegistro(id);
                if (VehiculoDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorVehiculoGUI mapper = new MapeadorVehiculoGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloVehiculo modelo = mapper.MapearTipo1Tipo2(VehiculoDTO);
                return View(modelo);
            }
        }

        [HttpGet]
        public ActionResult UploadFile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloCargaImagenVehiculo modelo = CrearModeloCargarImagenVehiculo(id);
            return View(modelo);
        }

        private ModeloCargaImagenVehiculo CrearModeloCargarImagenVehiculo(int? id)
        {
            IEnumerable<FotoVehiculoDTO> listaDTO = logica.ListaFotosVehiculoPorId(id.Value);
            MapeadorFotoVehiculoGUI mapeador = new MapeadorFotoVehiculoGUI();
            IEnumerable<ModeloFotoVehiculo> listaFotos = mapeador.MapearTipo1Tipo2(listaDTO);
            if(listaFotos == null)
            {
                listaFotos = new List<ModeloFotoVehiculo>();
            }
            ModeloCargaImagenVehiculo modelo = new ModeloCargaImagenVehiculo()
            {
                Id = id.Value,
                ListaImagenesVehiculo = listaFotos
            };
            return modelo;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFile(ModeloCargaImagenVehiculo modelo)
        {
            try
            {
                if (modelo.Archivo.ContentLength > 0)
                {
                    try
                    {
                        DateTime ahora = DateTime.Now;
                        string fecha_nombre = String.Format("{0}_{1}_{2}_{3}_{4}_{5}",
                                                ahora.Day, ahora.Month, ahora.Year, ahora.Hour,
                                                ahora.Minute, ahora.Millisecond);

                        string nombreArchivo = String.Concat(fecha_nombre, "_",
                                               Path.GetFileName(modelo.Archivo.FileName));

                        string rutaCarpeta = DatosGenerales.RutaArchivosVehiculos;
                        string rutaCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreArchivo);
                        modelo.Archivo.SaveAs(rutaCompletaArchivo);
                        FotoVehiculoDTO dto = new FotoVehiculoDTO()
                        {
                            IdVehiculo = modelo.Id,
                            NombreFoto = nombreArchivo

                        };

                        logica.GuardarNombreFoto(dto);
                        ViewBag.UploadFileMessage = "Archivo cargado correctamente";
                        ModeloCargaImagenVehiculo modeloView = CrearModeloCargarImagenVehiculo(modelo.Id); 
                        return View(modeloView);
                    }
                    catch
                    {

                    }
                  
                }
                ViewBag.UploadFileMessage = "Por favor selecciones un archivo";
                return View();
            }
            catch (Exception e)
            {
                ViewBag.UploadFileMessage = "Error al cargar el archivo";
                return View();
            }
        }

        [HttpPost]
        public ActionResult EliminarFoto (int idFotoVehiculo, string nombreFotoVehiculo)
        {
            bool respuesta = logica.EliminarRegistroFoto(idFotoVehiculo);
            if (respuesta)
            {
                string rutaCarpeta = DatosGenerales.RutaArchivosVehiculos;
                string CarpetaEliminados = DatosGenerales.CarpetaFotosVehiculosEliminadas;

                string rutaOrigenCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta), nombreFotoVehiculo);
                string rutaDestinoCompletaArchivo = Path.Combine(Server.MapPath(rutaCarpeta),CarpetaEliminados, nombreFotoVehiculo);
                System.IO.File.Move(rutaOrigenCompletaArchivo,rutaDestinoCompletaArchivo);
            }
           return RedirectToAction("Index");            
        }
    }
}
