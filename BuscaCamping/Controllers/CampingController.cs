﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuscaCamping.DataAccess.DataReaders;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.ViewModels;


namespace BuscaCamping.Controllers
{
    public class CampingController : Controller
    {
        GestorCamping gc = new GestorCamping();
        GestorZonas gz = new GestorZonas();
        CampingViewModel cvm = new CampingViewModel();
        ServicioViewModel svm = new ServicioViewModel();
        GestorServicio gs = new GestorServicio();

        // GET: Camping
        public ActionResult IndexCamping()
        {
            var camping = gc.ObtenerListaCamping();
            return View(camping);
        }

        // GET: Camping/Details/5
        public ActionResult DetailsCamping(int id)
        {
            var camping = gc.ObtenerCamping(id);
            return View(camping);
        }

        public JsonResult ListarDepartamentos(int id)
        {
            List<SelectListItem> lista = gz.ObtenerDepartamentos(id).ConvertAll(x => new SelectListItem { Text = x.NombreDepartamento, Value = x.IdDepartamento.ToString() });

            return Json(new SelectList(lista, "Value", "Text"));
        }

        public JsonResult Listarlocalidades(int id)
        {
            List<SelectListItem> lista = gz.ObtenerLocalidades(id).ConvertAll(x => new SelectListItem { Text = x.NombreLocalidad, Value = x.IdLocalidad.ToString() });

            return Json(new SelectList(lista, "Value", "Text"));
        }

        // GET: Camping/Create
        public ActionResult CreateCamping()
        {
            ViewData["prov"] = gz.ObtenerProvincias().ConvertAll(x => new SelectListItem { Text = x.NombreProvincia, Value = x.IdProvincia.ToString() });
          

            return View(cvm);
        }


        [HttpPost]
        public ActionResult CreateCamping(CampingViewModel cvm)
        {
            gc.AgregarCamping(cvm);
            return RedirectToAction("AgregarServicios");
        }

        // GET: Camping/Edit/5
        public ActionResult EditCamping(int idCamping)
        {
            ViewData["prov"] = gz.ObtenerProvincias().ConvertAll(x => new SelectListItem { Text = x.NombreProvincia, Value = x.IdProvincia.ToString() });
            cvm.camping = gc.ObtenerCamping(idCamping);

            return View(cvm);
        }

        // POST: Camping/Edit/5
        [HttpPost]
        public ActionResult EditCamping(CampingViewModel cvm)
        {
            gc.EditarCamping(cvm);
            return RedirectToAction("IndexCamping");
        }

        // GET: Camping/Delete/5
        public ActionResult Delete(int id)
        {
            gc.EliminarCamping(id);
            return RedirectToAction("IndexCamping");
        }

        public ActionResult AgregarServicios()
        {
            
            svm.ListaServicio = gs.ObtenerTodosServicios();

            return View(svm);
        }


        [HttpPost]
        public ActionResult AgregarServicios(ServicioViewModel svm)
        {
            gs.AgregarServicioPorCamp(svm);
            return RedirectToAction("IndexCamping");
        }

        public void savedata(FormCollection fomr)
        {
            
            string surname = Request.Form["surname"];
            string age = Request.Form["age"];
            string gender = Request.Form["gender"];
        }


    }
}
