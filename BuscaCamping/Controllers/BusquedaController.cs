using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

using System.Web.Mvc;
using BuscaCamping.DataAccess.DataReaders;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.DTO;
using BuscaCamping.DataAccess.ViewModels;
using System.ComponentModel.DataAnnotations;


namespace BuscaCamping.Controllers
{
    public class BusquedaController : Controller
    {
        GestorCamping gc = new GestorCamping();
        GestorBusqueda gb = new GestorBusqueda();
        GestorZonas gz = new GestorZonas();
        CampingViewModel cvm = new CampingViewModel();
        





        public ActionResult BuscarPorProvincia()
        {        
            var camping = gc.ObtenerListaCamping();
            return View(camping);
        }

        [HttpPost]
        public JsonResult BuscarPorProvincia(string Nombre, int[]Selected,int Total)
        {
            if(Nombre=="" && Selected==null)
            {
                return Json(new { msg = "Elija un parametro de búsqueda "});
            }
            var CampingPorParametro = gb.BuscarPorParametros(Nombre, Selected, Total);

            if (CampingPorParametro.Count==0)
            {
                return Json(new { msg = "No hay resultados " });
            }
                   
            return Json(CampingPorParametro);

        }

        [HttpPost]
        public JsonResult Index(string Prefix)
        {
            //Note : you can bind same list from database  
            var Todas = gz.ObtenerTodas();
            //Searching records from list using LINQ query  
            var CityName = (from N in Todas
                            where  N.NombreBusqueda.StartsWith(Prefix)
                            select new { N.NombreBusqueda });
            return Json(CityName, JsonRequestBehavior.AllowGet);
        }
    }

}

