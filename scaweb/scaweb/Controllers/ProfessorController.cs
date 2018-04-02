using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scaweb.Daos;
using scaweb.Models;

namespace scaweb.Controllers {
    public class ProfessorController : Controller {
        // GET: Professor
        public ActionResult Index() {
            return View(ProfessorDAO.BuscarTodos());
        }

        // GET: Professor/Details/5
        public ActionResult Details(int id) {

            Professor professor = ProfessorDAO.BuscarPorId(id);
            if (professor == null) {
                return HttpNotFound();
            }
            return View(professor);

        }

        // GET: Professor/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Professor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                Professor professor = new Professor();
                professor.Nome = collection["Nome"];
                professor.Cpf = collection["Cpf"];
                professor.DataNascimento = Convert.ToDateTime(collection["DataNascimento"]);
                professor.Email = collection["Email"];
                professor.Endereco = collection["Endereco"];
                professor.Telefone = collection["Telefone"];
                professor.Identidade = collection["Identidade"];
                professor.Matricula = collection["Matricula"];
                professor.TitulacaoMaxima = Convert.ToInt32(collection["TitulacaoMaxima"]);
                ProfessorDAO.Persistir(professor);

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int id) {
            Professor professor = ProfessorDAO.BuscarPorId(id);
            if (professor == null) {
                return HttpNotFound();
            }

            return View(professor);
        }

        // POST: Professor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Professor professor = new Professor();
                professor.Id = id;
                professor.Nome = collection["Nome"];
                professor.Cpf = collection["Cpf"];
                professor.DataNascimento = Convert.ToDateTime(collection["DataNascimento"]);
                professor.Email = collection["Email"];
                professor.Endereco = collection["Endereco"];
                professor.Telefone = collection["Telefone"];
                professor.Identidade = collection["Identidade"];
                professor.Matricula = collection["Matricula"];
                professor.TitulacaoMaxima = Convert.ToInt32(collection["TitulacaoMaxima"]);
                if (!ProfessorDAO.Persistir(professor)) {
                    return View(professor);
                }
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int id) {
            Professor professor = ProfessorDAO.BuscarPorId(id);
            if (professor == null) {
                return HttpNotFound();

            }
            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here
                ProfessorDAO.ExcluirPorId(id);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
