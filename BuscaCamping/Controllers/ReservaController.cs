using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BuscaCamping.DataAccess.DataReaders;
using BuscaCamping.DataAccess.Modelo;
using BuscaCamping.DataAccess.DTO;
using BuscaCamping.DataAccess.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace BuscaCamping.Controllers
{
   
    public class ReservaController : Controller
    {
        GestorReserva gr = new GestorReserva();
        DetalleReservaViewModel rvm = new DetalleReservaViewModel();
        GestorServicio gs = new GestorServicio();
        GestorCamping gc = new GestorCamping();
        GestorCliente gcl = new GestorCliente();

        // GET: Reserva
        [Authorize(Roles = "Administrador")]
        public ActionResult IndexReserva()
        {
            var reservas = gr.ObtenerListaReservas();
            return View(reservas);
        }

        // GET: Reserva/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult DetailsReserva(int id)
        {
            rvm.DetalleReserva = gr.ObtenerReserva(id);
            rvm.ListaDetallesPorReserva = gr.ObtenerDetallePorReserva(id);
            return View(rvm);
        }

        // GET: Reserva/Create
        [Authorize(Roles = "Administrador, User")]
        public ActionResult CreateReserva(int idCamping)
        {
            rvm.ListaServiciosAlojamiento = gs.ObtenerListaServiciosAlojamiento(idCamping);
            rvm.Camping = gc.ObtenerCamping(idCamping);        
            return View(rvm);
        }

        // POST: Reserva/Create
        [HttpPost]
        [Authorize(Roles = "Administrador, User")]
        public JsonResult CreateReserva(int idCamp, Detalles detalles)
        {
            var id =User.Identity.GetUserId();
            var listaUsuarios = gcl.ClientesUsers();
            var exito=true;
            
           
            foreach(Cliente c in listaUsuarios)
            {
                if (id != c.CodUser)
                {
                    exito = false;
                }
            }

            if(exito == true &&listaUsuarios.Count>0) {
                gr.Transaction(3, idCamp, detalles);
                return Json(new { success = true });
            }

            
            return Json(new { success = false });
        }


        [Authorize(Roles = "Administrador")]
        public ActionResult CancelarReserva(int idReserva)
        {
            gr.CancelarReserva(idReserva);
            return RedirectToAction("IndexReserva");
        }

       


    }
}
