using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PedidoDeliveryController : Controller
    {
        // GET: PedidoDelivery
        Context db = new Context();

        public ActionResult PedidoDelivery()
        {
            return View(db.PedidoDelivery.ToList());
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
        public ActionResult gvpPedidoDelivery()
        {
            var model = db1.PedidoDelivery;
            return PartialView("_gvpPedidoDelivery", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoDeliveryAddNew(Restaurante.CE_PedidoDelivery item)
        {
            var model = db1.PedidoDelivery;
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
            return PartialView("_gvpPedidoDelivery", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoDeliveryUpdate(Restaurante.CE_PedidoDelivery item)
        {
            var model = db1.PedidoDelivery;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.pedDeliId == item.pedDeliId);
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
            return PartialView("_gvpPedidoDelivery", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoDeliveryDelete(System.Int32 pedDeliId)
        {
            var model = db1.PedidoDelivery;
            if (pedDeliId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.pedDeliId == pedDeliId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPedidoDelivery", model.ToList());
        }
    }
}