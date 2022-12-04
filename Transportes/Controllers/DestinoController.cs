using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class DestinoController : Controller
    {
        // GET: Destino
        public ActionResult Index(){
            List<Destino> destinos = Destino.GetAllDestinos();
            return View(destinos);
        }

        public ActionResult Registro(int id)
        {
            Destino destino = Destino.GetById(id);
            return View(destino);
        }

        public ActionResult Guardar(int id, int idMunicipio)
        {
            Destino.Guardar(id, idMunicipio);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Destino.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}