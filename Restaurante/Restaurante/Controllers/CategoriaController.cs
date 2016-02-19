using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        Context db = new Context();

        public ActionResult Categoria()
        {
            return View(db.Categoria.ToList());
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
        public ActionResult gvpCategoria()
        {
            var model = db1.Categoria;
            return PartialView("_gvpCategoria", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCategoriaAddNew(Restaurante.CE_Categoria item)
        {
            var model = db1.Categoria;
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
            return PartialView("_gvpCategoria", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCategoriaUpdate(Restaurante.CE_Categoria item)
        {
            var model = db1.Categoria;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.categId == item.categId);
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
            return PartialView("_gvpCategoria", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpCategoriaDelete(System.Int32 categId)
        {
            var model = db1.Categoria;
            if (categId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.categId == categId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpCategoria", model.ToList());
        }
    }
}