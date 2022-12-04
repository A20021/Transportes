using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transportes.core.Entidades;

namespace Transportes.Controllers
{
    public class AutobusController : Controller
    {
        // GET: Autobus
        public ActionResult Index()
        {
            List<Autobus> autobuses = Autobus.GetAllAutobuses();
            return View(autobuses);
        }

        public ActionResult Registro(int id)
        {
            Autobus autobus = Autobus.GetById(id);
            return View(autobus);
        }

        public ActionResult Guardar(int id, String marca, String color, String placa, int matricula, int idRuta)
        {
            Autobus.Guardar(id, marca, color, placa, matricula, idRuta);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Autobus.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}