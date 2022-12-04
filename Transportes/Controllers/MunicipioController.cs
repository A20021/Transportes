using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class MunicipioController : Controller
    {
        // GET: Municipio
        public ActionResult Index(){
            List<Municipio> municipios = Municipio.GetAllMunicipios();
            return View(municipios);
        }

        public ActionResult Registro(int id)
        {
            Municipio municipio = Municipio.GetById(id);
            return View(municipio);
        }

        public ActionResult Guardar(int id, String nombre, int idEstado)
        {
            Municipio.Guardar(id, nombre, idEstado);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Municipio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}