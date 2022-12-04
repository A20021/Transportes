using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class RutaController : Controller
    {
        // GET: Ruta
        public ActionResult Index(){
            List<Ruta> rutas = Ruta.GetAllRutas();
            return View(rutas);
        }

        public ActionResult Registro(int id)
        {
            Ruta ruta = Ruta.GetById(id);
            return View(ruta);
        }

        public ActionResult Guardar(int id, String descripcion, int idEstado, int idPasajero, int idDestino, int idPartida)
        {
            Ruta.Guardar(id, descripcion, idEstado, idPasajero, idDestino, idPartida);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Ruta.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}