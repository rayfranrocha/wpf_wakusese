using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class UsuarioPerfilController : Controller
    {
        // GET: UsuarioPerfil
        Context db = new Context();

        public ActionResult UsuarioPerfil()
        {
            return View(db.UsuarioPerfil.ToList());
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
        public ActionResult gvpUsuarioPerfil()
        {
            var model = db1.UsuarioPerfil;
            return PartialView("_gvpUsuarioPerfil", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpUsuarioPerfilAddNew(Restaurante.CE_UsuarioPerfil item)
        {
            var model = db1.UsuarioPerfil;
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
            return PartialView("_gvpUsuarioPerfil", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpUsuarioPerfilUpdate(Restaurante.CE_UsuarioPerfil item)
        {
            var model = db1.UsuarioPerfil;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.usuarioPerfilId == item.usuarioPerfilId);
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
            return PartialView("_gvpUsuarioPerfil", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpUsuarioPerfilDelete(System.Int32 usuarioPerfilId)
        {
            var model = db1.UsuarioPerfil;
            if (usuarioPerfilId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.usuarioPerfilId == usuarioPerfilId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpUsuarioPerfil", model.ToList());
        }
    }
}