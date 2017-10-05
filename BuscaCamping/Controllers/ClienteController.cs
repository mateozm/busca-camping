using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuscaCamping.DataAccess.DataReaders;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;


namespace BuscaCamping.Controllers
{
    public class ClienteController : Controller
    {
        GestorCliente gc = new GestorCliente();
        GestorZonas gz = new GestorZonas();
        ClienteViewModel cvm = new ClienteViewModel();

        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = gc.ObtenerTodos();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var cliente = gc.ObtenerCliente(id);
            return View(cliente);
        }

        public JsonResult ListarDepartamentos(int id)
        {
            List<SelectListItem> lista = gz.ObtenerDepartamentos(id).ConvertAll(x => new SelectListItem { Text = x.NombreDepartamento, Value = x.IdDepartamento.ToString() });
           
            return Json(new SelectList(lista,"Value","Text"));
        }

        public JsonResult Listarlocalidades(int id)
        {
            List<SelectListItem> lista = gz.ObtenerLocalidades(id).ConvertAll(x => new SelectListItem { Text = x.NombreLocalidad, Value = x.IdLocalidad.ToString() });
           
            return Json(new SelectList(lista, "Value", "Text"));
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            
            ViewData["prov"] = gz.ObtenerProvincias().ConvertAll(x => new SelectListItem { Text = x.NombreProvincia, Value = x.IdProvincia.ToString() });
            

            cvm.sexos = gc.ObtenerSexos();
            
            return View(cvm);
        }

        
        [HttpPost]
        public ActionResult Create(ClienteViewModel cvm)
        {

            gc.AgregarCliente(cvm);
            return RedirectToAction("Index");

        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            gc.Eliminar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int idCliente)
        {
            ViewData["prov"] = gz.ObtenerProvincias().ConvertAll(x => new SelectListItem { Text = x.NombreProvincia, Value = x.IdProvincia.ToString() });
            cvm.cliente= gc.ObtenerCliente(idCliente);
            cvm.sexos = gc.ObtenerSexos();
         

            return View(cvm);
        }

        [HttpPost]
        public ActionResult Edit(ClienteViewModel cvm)
        {                          
                gc.EditarCliente(cvm);
                return RedirectToAction("Index");      
        
        }
    }
}
