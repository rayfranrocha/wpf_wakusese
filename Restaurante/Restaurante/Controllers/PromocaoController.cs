using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PromocaoController : Controller
    {
        Context db = new Context();

        public ActionResult Promocao()
        {
            return View(db.Promocao.ToList());
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
        public ActionResult gvpPromocao()
        {
            var model = db1.Promocao;
            return PartialView("_gvpPromocao", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPromocaoAddNew(Restaurante.CE_Promocao item)
        {
            var model = db1.Promocao;
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
            return PartialView("_gvpPromocao", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPromocaoUpdate(Restaurante.CE_Promocao item)
        {
            var model = db1.Promocao;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.promoId == item.promoId);
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
            return PartialView("_gvpPromocao", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPromocaoDelete(System.Int32 promoId)
        {
            var model = db1.Promocao;
            if (promoId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.promoId == promoId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPromocao", model.ToList());
        }
    }
}