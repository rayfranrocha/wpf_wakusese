using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        Context db = new Context();

        public ActionResult Empresa()
        {
            return View(db.Empresa.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        Context db1 = new Context();

        [ValidateInput(false)]
        public ActionResult gvpEmpresa()
        {
            var model = db1.Empresa;
            return PartialView("_gvpEmpresa", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpEmpresaAddNew(CE_Empresa item)
        {
            var model = db1.Empresa;
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
            return PartialView("_gvpEmpresa", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpEmpresaUpdate(CE_Empresa item)
        {
            var model = db1.Empresa;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.empresaId == item.empresaId);
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
            return PartialView("_gvpEmpresa", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpEmpresaDelete(System.Int32 empresaId)
        {
            var model = db1.Empresa;
            if (empresaId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.empresaId == empresaId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpEmpresa", model.ToList());
        }
    }
}