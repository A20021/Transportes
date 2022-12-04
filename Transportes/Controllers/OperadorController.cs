using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class OperadorController : Controller
    {
        // GET: Operador
        public ActionResult Index()
        {
            List<Operador> operadores = Operador.GetAllOperadores();
            return View(operadores);
        }


        public ActionResult Registro(int id)
        {
            Operador operador = Operador.GetById(id);
            return View(operador);
        }

        public ActionResult Guardar(int id, String nombre, int edad)
        {
            Operador.Guardar(id, nombre, edad);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Operador.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}