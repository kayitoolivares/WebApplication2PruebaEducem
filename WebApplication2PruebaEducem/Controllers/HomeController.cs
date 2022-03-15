using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2PruebaEducem.Models;

namespace WebApplication2PruebaEducem.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(string msg="")
        {
            ViewBag.msg = msg;  
            return View();
        }


       

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", new { msg = "Sesion cerrada" });
        }

        public ActionResult IndexDentro()
        {
            return RedirectToAction("Index", "Perfil");
        }


        [HttpPost]
        public ActionResult Login(string usuario, string pass)
        {
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(pass))
            {
                educemPruebaEntities1 db = new educemPruebaEntities1();
                var usr= db.usuario.Select(c=> new  { c.id, c.id_personal, c.tipo, c.usuario1, c.pass }).FirstOrDefault(e=> e.usuario1 == usuario && e.pass  ==pass);

                if (usr != null)
                {

                    FormsAuthentication.SetAuthCookie(usr.usuario1, true);
                    FormsAuthentication.SetAuthCookie (usr.usuario1 + "|" + usr.tipo + "|" +usr.id, true);
                    //System.Web.HttpContext.Current.Session["ususario"] = usr.usuario1;
                    //System.Web.HttpContext.Current.Session["Tipo"] = usr.tipo;
                    //System.Web.HttpContext.Current.Session["id_usuario"] = usr.id;
                    return RedirectToAction("Index", "Perfil");
                   

                }
                else
                {
                    return RedirectToAction("Index", new { msg = "usuario o password incorrecto" });
                  


                }
            }
            else{
                return RedirectToAction("Index", new { msg = "Llenar datos" });
                //return Index("Llenar datos");
            }


        }

        
       


    }

   

}