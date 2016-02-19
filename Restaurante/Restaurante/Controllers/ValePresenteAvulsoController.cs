using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class ValePresenteAvulsoController : Controller
    {
        // GET: ValePresenteAvulso
        Context db = new Context();

        public ActionResult ValePresenteAvulso()
        {
            return View(db.ValePresenteAvulso.ToList());
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
        public ActionResult gvpValePresenteAvulso()
        {
            var model = db1.ValePresenteAvulso;
            return PartialView("_gvpValePresenteAvulso", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpValePresenteAvulsoAddNew(Restaurante.CE_ValePresenteAvulso item)
        {
            var model = db1.ValePresenteAvulso;
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
            return PartialView("_gvpValePresenteAvulso", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpValePresenteAvulsoUpdate(Restaurante.CE_ValePresenteAvulso item)
        {
            var model = db1.ValePresenteAvulso;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.valePresId == item.valePresId);
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
            return PartialView("_gvpValePresenteAvulso", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpValePresenteAvulsoDelete(System.Int32 valePresId)
        {
            var model = db1.ValePresenteAvulso;
            if (valePresId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.valePresId == valePresId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpValePresenteAvulso", model.ToList());
        }
    }
}