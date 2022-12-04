using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class PartidaController : Controller
    {
        // GET: Partida
        public ActionResult Index(){
            List<Partida> partidas = Partida.GetAllPartidas();
            return View(partidas);
        }

        public ActionResult Registro(int id)
        {
            Partida partida = Partida.GetById(id);
            return View(partida);
        }

        public ActionResult Guardar(int id, int idMunicipio)
        {
            Partida.Guardar(id, idMunicipio);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Partida.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}