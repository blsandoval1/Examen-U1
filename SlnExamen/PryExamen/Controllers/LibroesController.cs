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
    public class LibroesController : Controller
    {

        // GET: Libroes
        public ActionResult Index()
        {
            ViewBag.Title = "Listado de Libros registrados";

            return View(LibroBLL.List());
        }

        // GET: Libroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libroes/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1");
            return View();
        }

        // POST: Libroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_libros,titulo,autores,ISBN,fecha_publicacion,numero,id_categoria")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Create(libro);
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1", libro.id_categoria);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1", libro.id_categoria);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_libros,titulo,autores,ISBN,fecha_publicacion,numero,id_categoria")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Update(libro);
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(CategoriaBLL.List(), "id_categoria", "categoria1", libro.id_categoria);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libro libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroBLL.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
