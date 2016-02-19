using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PerfilPadraoEnumController : Controller
    {
        // GET: PerfilPadraoEnum
        Context db = new Context();

        public ActionResult PerfilPadraoEnum()
        {
            return View(db.PerfilPadraoEnum.ToList());
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
        public ActionResult gvpPerfilPadraoEnum()
        {
            var model = db1.PerfilPadraoEnum;
            return PartialView("_gvpPerfilPadraoEnum", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPerfilPadraoEnumAddNew(Restaurante.CE_PerfilPadraoEnum item)
        {
            var model = db1.PerfilPadraoEnum;
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
            return PartialView("_gvpPerfilPadraoEnum", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPerfilPadraoEnumUpdate(Restaurante.CE_PerfilPadraoEnum item)
        {
            var model = db1.PerfilPadraoEnum;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.perfilPadraoEnumId == item.perfilPadraoEnumId);
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
            return PartialView("_gvpPerfilPadraoEnum", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPerfilPadraoEnumDelete(System.Int32 perfilPadraoEnumId)
        {
            var model = db1.PerfilPadraoEnum;
            if (perfilPadraoEnumId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.perfilPadraoEnumId == perfilPadraoEnumId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPerfilPadraoEnum", model.ToList());
        }
    }
}