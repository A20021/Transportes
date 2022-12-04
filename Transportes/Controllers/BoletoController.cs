using Transportes.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transportes.Controllers
{
    public class BoletoController : Controller
    {
        // GET: Boleto
        public ActionResult Index(){
            List<Boleto> boletos = Boleto.GetAllBoletos();
            return View(boletos);
        }

        public ActionResult Registro(int id)
        {
            Boleto boleto = Boleto.GetById(id);
            return View(boleto);
        }

        public ActionResult Guardar(int id, int numeroBoleto)
        {
            Boleto.Guardar(id, numeroBoleto);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int id)
        {
            Boleto.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}