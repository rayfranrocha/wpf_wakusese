using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class UsuarioController : Controller
    {
        Context db = new Context();
        // GET: Usuario
        public ActionResult Usuario()
        {
            return View(db.Usuario.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        Context db1 = new Context();

        [ValidateInput(false)]
        public ActionResult gvpUsuario()
        {
            var model = db1.Usuario;
            return PartialView("_gvpUsuario", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpUsuarioAddNew(CE_Usuario item)
        {
            var model = db1.Usuario;
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
            return PartialView("_gvpUsuario", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpUsuarioUpdate(CE_Usuario item)
        {
            var model = db1.Usuario;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.usuId == item.usuId);
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
            return PartialView("_gvpUsuario", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpUsuarioDelete(System.Int32 usuId)
        {
            var model = db1.Usuario;
            if (usuId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.usuId == usuId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpUsuario", model.ToList());
        }
    }
}