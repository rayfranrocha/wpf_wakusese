using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Restaurante.Controllers
{
    public class EnderecoController : Controller
    {
        private Context db = new Context();
        
        [Authorize(Roles="Admin")]
        public ActionResult Endereco()
        {
            return View(db.Endereco.ToList());
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
        public ActionResult gvpEndereco()
        {
            var model = db1.Endereco;
            return PartialView("_gvpEndereco", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvpEnderecoAddNew(CE_Endereco item)
        {
            var model = db1.Endereco;
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
            return PartialView("_gvpEndereco", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpEnderecoUpdate(CE_Endereco item)
        {
            var model = db1.Endereco;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.endeId == item.endeId);
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
            return PartialView("_gvpEndereco", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpEnderecoDelete(System.Int32 endeId)
        {
            var model = db1.Endereco;
            if (endeId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.endeId == endeId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpEndereco", model.ToList());
        }
    }
}