using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class CaracteristicaController : Controller
    {
        // GET: Caracteristica
        Context db = new Context();

        public ActionResult Caracteristica()
        {
            return View(db.Caracteristica.ToList());
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
        public ActionResult gvpCaracteristica()
        {
            var model = db1.Caracteristica;
            return PartialView("_gvpCaracteristica", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCaracteristicaAddNew(Restaurante.CE_Caracteristica item)
        {
            var model = db1.Caracteristica;
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
            return PartialView("_gvpCaracteristica", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCaracteristicaUpdate(Restaurante.CE_Caracteristica item)
        {
            var model = db1.Caracteristica;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.caractId == item.caractId);
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
            return PartialView("_gvpCaracteristica", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCaracteristicaDelete(System.Int32 caractId)
        {
            var model = db1.Caracteristica;
            if (caractId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.caractId == caractId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpCaracteristica", model.ToList());
        }
    }
}