using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuscaCamping.DataAccess.DataReaders;
using BuscaCamping.DataAccess.ViewModels;
using BuscaCamping.DataAccess.Modelo;
using Microsoft.AspNet.Identity;

namespace BuscaCamping.Controllers
{
    [Authorize(Roles = "Administrador, User")]
    public class OpinionController : Controller
    {
        OpinionViewModel ovm = new OpinionViewModel();
        Opinion opinion = new Opinion();
        GestorOpinion go = new GestorOpinion();
        GestorCamping gc = new GestorCamping();

      
        public ActionResult CreateOpinion(int idCamping)
        {
            ovm.Camping = gc.ObtenerCamping(idCamping);                   
            return View(ovm);
        }

       
        [HttpPost]
        public ActionResult CreateOpinion(OpinionViewModel ovm)
        {
            var id = User.Identity.GetUserId();
            go.AgregarOpinion(ovm, id);           
            return RedirectToAction("IndexCamping", "Camping");
        }
    }
}
