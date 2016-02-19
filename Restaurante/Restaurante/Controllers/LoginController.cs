using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Restaurante.Controllers
{
    public class LoginController : Controller
    {
        Context db = new Context();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CE_Usuario usuario, string returnURL, CE_UsuarioPerfil usuper)
        {
            Context db = new Context();
            if (ModelState.IsValid)
            {
                //string username = usuario.usuNome;
                //string password = usuario.usuSenha;
                //string teste = test.perfilPadraoEnumTipo;

                string username = usuario.usuNome;
                string password = usuario.usuSenha;

                bool userValid = db.UsuarioPerfil.Any(user => user.Usuario.usuNome == username && user.Usuario.usuSenha == password);

                // bool b = db.Perfil.Any(a => a.PerfilPadraoEnum.perfilPadraoEnumTipo == teste);

                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    if (Url.IsLocalUrl(returnURL) && returnURL.Length > 1 && returnURL.StartsWith("/")
                        && !returnURL.StartsWith("//") && !returnURL.StartsWith("/\\"))
                    { 
                        return Redirect(returnURL);
                       
                    }
                    else
                    {

//                        return View("LoginInvalido");
                        return RedirectToAction("Index", "Menu");

                    }
                }
                else
                {
                    if (Url.IsLocalUrl(returnURL) && returnURL.Length > 1 && returnURL.StartsWith("/")
                        && !returnURL.StartsWith("//") && !returnURL.StartsWith("/\\"))
                    {
                        return View("LoginInvalido");
                        
                    }
                    else
                    {
                        return RedirectToAction("Index", "Menu");

                        //return View("LoginInvalido");
                    }

                }
            }
            return View(usuario);
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        public ActionResult LoginInvalido()
        {
            return View();
        }
    }
}