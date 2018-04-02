using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scaweb.Daos;
using scaweb.Models;

namespace scaweb.Controllers
{
    public class DisciplinaController : Controller {
        // GET: Disciplina
        public ActionResult Index() {
            return View(DisciplinaDAO.BuscarTodos());
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(int id) {

            Disciplina disciplina = DisciplinaDAO.BuscarPorId(id);
            if (disciplina == null) {
                return HttpNotFound();
            }
            return View(disciplina);

        }

        // GET: Disciplina/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                Disciplina disciplina = new Disciplina();
                disciplina.Descricao = collection["Descricao"];
                DisciplinaDAO.Persistir(disciplina);

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int id) {
            Disciplina disciplina = DisciplinaDAO.BuscarPorId(id);
            if (disciplina == null) {
                return HttpNotFound();
            }

            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Disciplina disciplina = new Disciplina();
                disciplina.Id = id;
                disciplina.Descricao = collection["Descricao"];

                if (!DisciplinaDAO.Persistir(disciplina)) {
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Disciplina/Delete/5
        public ActionResult Delete(int id) {
            Disciplina disciplina = DisciplinaDAO.BuscarPorId(id);
            if (disciplina == null) {
                return HttpNotFound();

            }
            return View(disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here
                DisciplinaDAO.ExcluirPorId(id);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
