using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class PedidoLocalController : Controller
    {
        // GET: PedidoLocal
        Context db = new Context();

        public ActionResult PedidoLocal()
        {
            return View(db.PedidoLocal.ToList());
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
        public ActionResult gvpPedidoLocal()
        {
            var model = db1.PedidoLocal;
            return PartialView("_gvpPedidoLocal", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoLocalAddNew(Restaurante.CE_PedidoLocal item)
        {
            var model = db1.PedidoLocal;
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
            return PartialView("_gvpPedidoLocal", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoLocalUpdate(Restaurante.CE_PedidoLocal item)
        {
            var model = db1.PedidoLocal;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.pedLocalId == item.pedLocalId);
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
            return PartialView("_gvpPedidoLocal", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpPedidoLocalDelete(System.Int32 pedLocalId)
        {
            var model = db1.PedidoLocal;
            if (pedLocalId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.pedLocalId == pedLocalId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpPedidoLocal", model.ToList());
        }
    }
}