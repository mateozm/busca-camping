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
    public class ServiciosController : Controller
    {
        CampingViewModel cvm = new CampingViewModel();
        GestorServicio gs = new GestorServicio();
        ServicioPorCamping spc = new ServicioPorCamping();

        public ActionResult SaveServPorCamp()
        {

            cvm.Listaservicios = gs.ObtenerTodosServicios();

            return View(cvm);
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
