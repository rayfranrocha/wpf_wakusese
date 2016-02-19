using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class ProdutoCaractValorController : Controller
    {
        // GET: ProdutoCaractValor
        Context db = new Context();

        public ActionResult ProdCaractValor()
        {
            return View(db.ProdCaractValor.ToList());
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
        public ActionResult gvpProdCaractValor()
        {
            var model = db1.ProdCaractValor;
            return PartialView("_gvpProdCaractValor", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpProdCaractValorAddNew(Restaurante.CE_ProdCaractValor item)
        {
            var model = db1.ProdCaractValor;
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
            return PartialView("_gvpProdCaractValor", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpProdCaractValorUpdate(Restaurante.CE_ProdCaractValor item)
        {
            var model = db1.ProdCaractValor;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.prodCaractValorId == item.prodCaractValorId);
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
            return PartialView("_gvpProdCaractValor", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpProdCaractValorDelete(System.Int32 prodCaractValorId)
        {
            var model = db1.ProdCaractValor;
            if (prodCaractValorId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.prodCaractValorId == prodCaractValorId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpProdCaractValor", model.ToList());
        }
    }
}