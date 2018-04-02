using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scaweb.Daos;
using scaweb.Models;

namespace scaweb.Controllers
{
    public class TurmaController : Controller
    {
        // GET: Turma
        public ActionResult Index()
        {
            return View(TurmaDAO.BuscarTodos());
        }

        // GET: Turma/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            ViewBag.instituicoes = InstituicaoDAO.BuscarTodos();
            ViewBag.Cursos = CursoDAO.BuscarTodos();
            ViewBag.professores = ProfessorDAO.BuscarTodos();
            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Turma turma = new Turma();
                turma.Numero = Convert.ToInt32(collection["Numero"]);
                turma.Instituicao = InstituicaoDAO.BuscarPorId(Convert.ToInt32(collection["Instituicao.Id"]));
                turma.Curso = CursoDAO.BuscarPorId(Convert.ToInt32(collection["Curso.Id"]));
                turma.Professor = ProfessorDAO.BuscarPorId(Convert.ToInt32(collection["Professor.Id"]));
                turma.Ano = Convert.ToInt32(collection["Ano"]);
                turma.Semestre = Convert.ToInt32(collection["Semestre"]);

                if (!TurmaDAO.Persistir(turma)) {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Turma/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Turma/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
