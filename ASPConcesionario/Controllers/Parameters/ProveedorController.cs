using ASPConcesionario.Helpers;
using ASPConcesionario.Mapeadores.Parametros;
using ASPConcesionario.Models.Parametros;
using LogicaNegocio.DTO.Parametros;
using LogicaNegocio.Implementacion.Parametros;
using PagedList;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;


namespace ASPConcesionario.Controllers.Parameters
{
    public class ProveedorController : Controller
    {
        private ImplProveedorLogica logica = new ImplProveedorLogica();

        // GET: Proveedor
        public ActionResult Index(int? page, string filtro = "")
        {
            int numPagina = page ?? 1;
            int registroPorPagina = DatosGenerales.RegistroPorPagina;
            int totalRegistro;
            IEnumerable<ProveedorDTO> listaDatos = logica.ListarRegistros(
                            filtro, numPagina, registroPorPagina, out totalRegistro);
            MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
            IEnumerable<ModeloProveedor> listaModelo = mapper.MapearTipo1Tipo2(listaDatos);
            //var registroPagina = listaModelo.ToPagedList(numPagina, 2);
            var listaPagina = new StaticPagedList<ModeloProveedor>
                (listaModelo, numPagina, registroPorPagina, totalRegistro);
            return View(listaPagina);
        }

        // GET: Proveedor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorDTO ProveedorDTO = logica.BuscarRegistro(id.Value);
            if (ProveedorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
            ModeloProveedor modelo = mapper.MapearTipo1Tipo2(ProveedorDTO);
            return View(modelo);
        }

        // GET: Proveedor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedor/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind(Include = "Id,Nombre")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ModeloProveedor modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
                ProveedorDTO ProveedorDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.GuardarRegistro(ProveedorDTO);
                return RedirectToAction("Index");
            }

            return View(modelo);
        }

        // GET: Proveedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorDTO ProveedorDTO = logica.BuscarRegistro(id.Value);
            if (ProveedorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
            ModeloProveedor modelo = mapper.MapearTipo1Tipo2(ProveedorDTO);
            return View(modelo);
        }

        // POST: Proveedor/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ModeloProveedor modelo)
        {
            if (ModelState.IsValid)
            {
                MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
                ProveedorDTO ProveedorDTO = mapper.MapearTipo2Tipo1(modelo);
                logica.EditarRegistro(ProveedorDTO);

                return RedirectToAction("Index");
            }
            return View(modelo);
        }

        // GET: Proveedor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProveedorDTO ProveedorDTO = logica.BuscarRegistro(id.Value);
            if (ProveedorDTO == null)
            {
                return HttpNotFound();
            }
            MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
            ModeloProveedor modelo = mapper.MapearTipo1Tipo2(ProveedorDTO);
            return View(modelo);
        }

        // POST: Proveedor/Delete/5
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
                ProveedorDTO ProveedorDTO = logica.BuscarRegistro(id);
                if (ProveedorDTO == null)
                {
                    return HttpNotFound();
                }
                MapeadorProveedorGUI mapper = new MapeadorProveedorGUI();
                ViewBag.mensaje = Mensajes.mensajeErrorEliminar;
                ModeloProveedor modelo = mapper.MapearTipo1Tipo2(ProveedorDTO);
                return View(modelo);
            }
        }
    }
}
