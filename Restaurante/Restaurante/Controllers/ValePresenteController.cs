using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Restaurante.Repository;

namespace Restaurante.Controllers
{
    public class ValePresenteController : Controller
    {
        // GET: ValePresente
        Context db = new Context();
        ValePresenteRepository valePreRepo = new ValePresenteRepository();

        public ActionResult ValePresente()
        {
            var valePresente = db.ValePresente.Include(c => c.Empresa);
            return View(valePresente.ToList());
        }

        public ActionResult DeleteValePresente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CE_ValePresente ceValePresente = db.ValePresente.Find(id);
            if (ceValePresente == null)
            {
                return HttpNotFound();
            }
            return View(ceValePresente);
        }


        [HttpPost]
        [ActionName("DeleteValePresente")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedValePresente(int id)
        {
            valePreRepo.DeleteConfirmedValePresente(id);
            return RedirectToAction("ValePresente");
        }

        public ActionResult EditValePresente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CE_ValePresente ceValePresente = db.ValePresente.Find(id);
            if (ceValePresente == null)
            {
                return HttpNotFound();
            }
            return View(ceValePresente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditValePresente(CE_ValePresente ceValePresente)
        {
            if (ModelState.IsValid)
            {
                valePreRepo.EditValePresente(ceValePresente);
                return RedirectToAction("ValePresente");
            }
            return View(ceValePresente);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CE_ValePresente ceValePresente)
        {
            if (ModelState.IsValid)
            {
                valePreRepo.CreateValePresente(ceValePresente);
                return RedirectToAction("ValePresente");
            }
            return View(ceValePresente);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}