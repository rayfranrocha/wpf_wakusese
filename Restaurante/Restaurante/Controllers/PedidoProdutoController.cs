using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PedidoProdutoController : Controller
    {
        // GET: PedidoProduto
        Context db = new Context();

        public ActionResult PedidoProduto()
        {
            return View(db.PedidoProduto.ToList());
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
        public ActionResult gvpPedidoProduto()
        {
            var model = db1.PedidoProduto;
            return PartialView("_gvpPedidoProduto", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoProdutoAddNew(Restaurante.CE_PedidoProduto item)
        {
            var model = db1.PedidoProduto;
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
            return PartialView("_gvpPedidoProduto", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoProdutoUpdate(Restaurante.CE_PedidoProduto item)
        {
            var model = db1.PedidoProduto;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.pedProdId == item.pedProdId);
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
            return PartialView("_gvpPedidoProduto", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoProdutoDelete(System.Int32 pedProdId)
        {
            var model = db1.PedidoProduto;
            if (pedProdId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.pedProdId == pedProdId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPedidoProduto", model.ToList());
        }
    }
}