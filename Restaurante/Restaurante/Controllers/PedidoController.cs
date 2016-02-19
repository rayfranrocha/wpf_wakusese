using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PedidoController : Controller
    {
        Context db = new Context();

        public ActionResult Pedido()
        {
            return View(db.Pedido.ToList());
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
        public ActionResult gvpPedido()
        {
            var model = db1.Pedido;
            return PartialView("_gvpPedido", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoAddNew(Restaurante.CE_Pedido item)
        {
            var model = db1.Pedido;
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
            return PartialView("_gvpPedido", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoUpdate(Restaurante.CE_Pedido item)
        {
            var model = db1.Pedido;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.pedidoId == item.pedidoId);
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
            return PartialView("_gvpPedido", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoDelete(System.Int32 pedidoId)
        {
            var model = db1.Pedido;
            if (pedidoId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.pedidoId == pedidoId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPedido", model.ToList());
        }
    }
}