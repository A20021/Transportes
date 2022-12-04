using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class PasajeroController : Controller
    {
        // GET: Pasajero
        public ActionResult Index(){
            List<Pasajero> pasajeros = Pasajero.GetAllPasajeros();
            return View(pasajeros);
        }

        public ActionResult Registro(int id)
        {
            Pasajero pasajero = Pasajero.GetById(id);
            return View(pasajero);
        }

        public ActionResult Guardar(int id, int idBoleto, int numeroAsiento)
        {
            Pasajero.Guardar(id, idBoleto, numeroAsiento);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Pasajero.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}