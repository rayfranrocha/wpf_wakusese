using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.IO;
using System.Drawing;

namespace Restaurante.Controllers
{
    public class ProdutoController : Controller
    {
        Context db = new Context();

        public ActionResult Produto()
        {
            return View(db.Produto.ToList());
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
        public ActionResult gvpProduto()
        {
            var model = db1.Produto;
            return PartialView("_gvpProduto", model.ToList());
        }



        [HttpPost, ValidateInput(false)]
        public ActionResult gvpProdutoAddNew(Restaurante.CE_Produto item)
        {
            var model = db1.Produto;
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
            return PartialView("_gvpProduto", model.ToList());
        }

        
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpProdutoUpdate(CE_Produto item)
        {
            var model = db1.Produto;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.prodId == item.prodId && it.prodImg1 == item.prodImg1);
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
            return PartialView("_gvpProduto", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvpProdutoDelete(System.Int32 prodId)
        {
            var model = db1.Produto;
            if (prodId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.prodId == prodId);
                    if (item != null)
                        model.Remove(item);
                    db1.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvpProduto", model.ToList());
        }


      //  Imagem no load =============================================================================================================

        public ActionResult BinaryImageColumnPhotoUpdate()
        {
            return BinaryImageEditExtension.GetCallbackResult();
        }



        public ActionResult ViewPage1(int? employeeID)
        {
            return View("ViewPage1", GetEmployee(employeeID.Value));
        }

        public CE_Produto GetEmployee(int employeeID)
        {
            Context DB = new Context();
            return (from employee in DB.Produto where employee.prodId == employeeID select employee).SingleOrDefault();
        }

    }
}