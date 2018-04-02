using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scaweb.Daos;
using scaweb.Models;

namespace scaweb.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult Index()
        {
            return View(CursoDAO.BuscarTodos());
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id) {

            Curso Curso = CursoDAO.BuscarPorId(id);
            if (Curso == null) {
                return HttpNotFound();
            }
            return View(Curso);

        }

        // GET: Curso/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                Curso curso = new Curso();
                curso.Descricao = collection["Descricao"];
                CursoDAO.Persistir(curso);

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id) {
            Curso curso = CursoDAO.BuscarPorId(id);
            if (curso == null) {
                return HttpNotFound();
            }

            return View(curso);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Curso curso = new Curso();
                curso.Id = id;
                curso.Descricao = collection["Descricao"];
          
                if (!CursoDAO.Persistir(curso)) {
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Delete(int id) {
            Curso curso = CursoDAO.BuscarPorId(id);
            if (curso == null) {
                return HttpNotFound();

            }
            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here
                CursoDAO.ExcluirPorId(id);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
