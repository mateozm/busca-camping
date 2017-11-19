using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuscaCamping.DataAccess.DataReaders;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace BuscaCamping.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ServiciosController : Controller
    {
        CampingViewModel cvm = new CampingViewModel();
        GestorServicio gs = new GestorServicio();
        ServicioPorCamping spc = new ServicioPorCamping();
        GestorCamping gc = new GestorCamping();
        ServicioViewModel svm = new ServicioViewModel();

        public ActionResult SaveServPorCamp(int idCamping)
        {
            svm.camping = gc.ObtenerCamping(idCamping);
            svm.ListaServicio = gs.ObtenerTodosServicios();

            return View(svm);
        }

        [HttpPost]
        public ActionResult SaveServPorCamp(Servicios servicios)
        {

            var array = servicios.values;

            foreach (ServiciosPorCampingDto s in array)
            {
                gs.AgregarServicioPorCamp(s);
            }
            return Json(new { data = true });
        }

        
        public ActionResult IndexServPorCamp(int id)
        {
            var servicios = gs.ObtenerListaServiciosPorCamping(id);
            return View(servicios);
        }

        
        public ActionResult DeleteServicioPorCamping(int id)
        {
            gs.EliminarServicio(id);
            return RedirectToAction("IndexCamping", "Camping");
        }

        
        public ActionResult EditServPorCamp(int idServicioPorCamping)
        {

            spc = gs.ObtenerServPorCamp(idServicioPorCamping);

            return View(spc);
        }

       
        [HttpPost]
        public ActionResult EditServPorCamp(ServicioPorCamping spc)
        {
            gs.EditarServicio(spc);
            return RedirectToAction("IndexCamping", "Camping");
        }



    }
}
