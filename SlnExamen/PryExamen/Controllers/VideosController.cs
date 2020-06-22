using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUExamen;
using BEUExamen.Transactions;

namespace PryExamen.Controllers
{
    public class VideosController : Controller
    {

        // GET: Videos
        public ActionResult Index()
        {
            return View(VideoBLL.List());
        }

        // GET: Videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(),"id_categoria", "categoria1");
            return View();
        }

        // POST: Videos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_video,titulo_video,fecha_publicacion_video,id_categoria,formato,duracion")] Video video)
        {
            if (ModelState.IsValid)
            {
                VideoBLL.Create(video);
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1", video.id_categoria); ;
            return View(video);
        }

        // GET: Videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1", video.id_categoria);
            return View(video);
        }

        // POST: Videos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_video,titulo_video,fecha_publicacion_video,id_categoria,formato,duracion")] Video video)
        {
            if (ModelState.IsValid)
            {
                VideoBLL.Update(video);
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1", video.id_categoria);
            return View(video);
        }

        // GET: Videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = VideoBLL.Get(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
