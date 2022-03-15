using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication2PruebaEducem.Models;
using System.Net;

namespace WebApplication2PruebaEducem.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        private educemPruebaEntities1 db = new educemPruebaEntities1();
        // GET: Perfil

        public ActionResult Index()
        {

             
           
            //var ntc = db.nota.Select(c => new { c.id, c.contenido, c.usuario.personal.nombre, c.usuario.personal.apematerno, c.fecha});
            //ViewBag.Lista = ntc.ToList();

            var nota = db.nota.Include(n => n.usuario).OrderByDescending(c=> c.fecha );
            return View(nota.ToList());

            //return View();
        }

        public  ActionResult Comentar(int? id)
        {

            if (id==null)
            {
                try
                {
                    id = Convert.ToInt32(TempData["Str"]);

                }
                catch (Exception)
                {

                    
                }

            }


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota nota = db.nota.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            TempData["Str"] = id;
            xxModel model = new xxModel();
            //var nota1 = db.nota.Include(n => n.usuario).OrderByDescending(c => c.fecha);
            var nota2 = db.notaComentario.Where(e => e.id_nota == id).Include(n => n.usuario).OrderByDescending(c => c.fecha);
            model.List1 = nota;
            model.List2 = nota2.ToList();
            return View(model);
            //return View(comentarios.ToList());

        }



        [HttpPost]
        public ActionResult Create(string contenido)
        {

            //[Bind(Include = "id,id_usuario,fecha,contenido")] ;
            nota nota=new nota();
            int userId = 0; 
            if (User.Identity.IsAuthenticated) 
            { 
                userId = Convert.ToInt32(User.Identity.Name.Split('|')[2]);
            }



            nota.id_usuario = userId;
            nota.fecha = DateTime.Now;
            nota.contenido = contenido;

            if (ModelState.IsValid)
            {
                db.nota.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.usuario, "id", "usuario1", nota.id_usuario);
            return View(nota);
        }

        [HttpPost]
        public ActionResult CreateComentario(int? idNota, string contenido )
        {

            //[Bind(Include = "id,id_usuario,fecha,contenido")] ;
            notaComentario nota = new notaComentario();
            int userId = 0;
            if (User.Identity.IsAuthenticated)
            {
                userId = Convert.ToInt32(User.Identity.Name.Split('|')[2]);
            }



            nota.id_usuario = userId;
            nota.fecha = DateTime.Now;
            nota.contenido = contenido;
            nota.id_nota = Convert.ToInt32( TempData["Str"]);

            if (ModelState.IsValid)
            {
                db.notaComentario.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Comentar/"+ idNota );
            }

            ViewBag.id_usuario = new SelectList(db.usuario, "id", "usuario1", nota.id_usuario);
            return View(nota);
        }
    }

    public class xxModel
    {

        public nota List1 { get; set; }

        public List<notaComentario> List2 { get; set; }

    }


}