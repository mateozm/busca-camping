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
    public class ReservaController : Controller
    {
        GestorReserva gr = new GestorReserva();
        ReservaViewModel rvm = new ReservaViewModel();
        GestorServicio gs = new GestorServicio();       

        // GET: Reserva
        public ActionResult IndexReserva()
        {
            rvm.ListaReservas = gr.ObtenerListaReservas();
            return View(rvm);
        }

        // GET: Reserva/Details/5
        public ActionResult DetailsReserva(int id)
        {
            rvm.DetalleReserva = gr.ObtenerReserva(id);
            rvm.ListaServicioPorReserva = gs.ObtenerListaServiciosPorReserva(id);
            return View(rvm);
        }

        // GET: Reserva/Create
        public ActionResult CreateReserva(int id)
        {
            rvm.ListaServiciosAlojamiento = gr.ObtenerServiciosAlojamiento(id);
            return View(rvm);
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult CreateReserva(ReservaViewModel reserva)
        {
            return null;
        }

        
    }
}
