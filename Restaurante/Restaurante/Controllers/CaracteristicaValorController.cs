using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class CaracteristicaValorController : Controller
    {
        // GET: CaracteristicaValor
        Context db = new Context();

        public ActionResult CaracteristicaValor()
        {
            return View(db.CaracteristicaValor.ToList());
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
        public ActionResult gvpCaracteristicaValor()
        {
            var model = db1.CaracteristicaValor;
            return PartialView("_gvpCaracteristicaValor", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCaracteristicaValorAddNew(Restaurante.CE_CaracteristicaValor item)
        {
            var model = db1.CaracteristicaValor;
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
            return PartialView("_gvpCaracteristicaValor", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCaracteristicaValorUpdate(Restaurante.CE_CaracteristicaValor item)
        {
            var model = db1.CaracteristicaValor;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.caractValId == item.caractValId);
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
            return PartialView("_gvpCaracteristicaValor", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCaracteristicaValorDelete(System.Int32 caractValId)
        {
            var model = db1.CaracteristicaValor;
            if (caractValId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.caractValId == caractValId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpCaracteristicaValor", model.ToList());
        }
    }
}