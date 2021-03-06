﻿using System;
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
    public class CampingController : Controller
    {
        GestorCamping gc = new GestorCamping();
        GestorZonas gz = new GestorZonas();
        CampingViewModel cvm = new CampingViewModel();        
        GestorServicio gs = new GestorServicio();
        GestorOpinion go = new GestorOpinion();

        // GET: Camping
        
        public ActionResult IndexCamping()
        {
            var camping = gc.ObtenerListaCamping();
            return View(camping);
        }

       
       

        // GET: Camping/Details/5
        [AllowAnonymous]
        public ActionResult DetailsCamping(int id)
        {
            cvm.camping = gc.ObtenerCamping(id);
            cvm.ListaServicioPorCamping = gs.ObtenerListaServiciosPorCamping(id);
            cvm.opiniones = go.ObtenerOpinionesPorCamping(id);
            return View(cvm);
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
            //cvm.Listaservicios = gs.ObtenerTodosServicios();

            return View(cvm);
        }


        [HttpPost]
        public ActionResult CreateCamping(CampingViewModel cvm)
        {            
            gc.AgregarCamping(cvm);
            var id = gc.ObtenerUltimoCamping();
            return RedirectToAction("SaveServPorCamp", "Servicios", new {idCamping=id });
        }

        // GET: Camping/Edit/5
        public ActionResult EditCamping(int idCamping)
        {
            ViewData["prov"] = gz.ObtenerProvincias().ConvertAll(x => new SelectListItem { Text = x.NombreProvincia, Value = x.IdProvincia.ToString() });
            cvm.camping = gc.ObtenerCamping(idCamping);
            cvm.ListaServicioPorCamping = gs.ObtenerListaServiciosPorCamping(idCamping);

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

       

    }
    } 
