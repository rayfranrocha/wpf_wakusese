using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        Context db = new Context();

        public ActionResult Perfil()
        {
            return View(db.Perfil.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        Restaurante.Context db1 = new Restaurante.Context();

        [ValidateInput(false)]
        public ActionResult gvpPerfil()
        {
            var model = db1.Perfil;
            return PartialView("_gvpPerfil", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPerfilAddNew(Restaurante.CE_Perfil item)
        {
            var model = db1.Perfil;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvpPerfil", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPerfilUpdate(Restaurante.CE_Perfil item)
        {
            var model = db1.Perfil;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.perfilId == item.perfilId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db1.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvpPerfil", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPerfilDelete(System.Int32 perfilId)
        {
            var model = db1.Perfil;
            if (perfilId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.perfilId == perfilId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPerfil", model.ToList());
        }
    }
}