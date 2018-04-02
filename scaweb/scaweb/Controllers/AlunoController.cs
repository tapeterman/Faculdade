using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scaweb.Daos;
using scaweb.Models;

namespace scaweb.Controllers
{
    public class AlunoController : Controller
    {
        // GET: Aluno
        public ActionResult Index()
        {
            return View(AlunoDAO.BuscarTodos());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {

            Aluno aluno = AlunoDAO.BuscarPorId(id);
            if (aluno == null) {
                return HttpNotFound();
            }
            return View(aluno);
          
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Aluno aluno = new Aluno();
                aluno.Nome = collection["Nome"];
                aluno.Cpf = collection["Cpf"];
                aluno.DataNascimento = Convert.ToDateTime(collection["DataNascimento"]);
                aluno.Email = collection["Email"];
                aluno.Endereco = collection["Endereco"];
                aluno.Telefone = collection["Telefone"];
                aluno.Identidade = collection["Identidade"];
                aluno.Matricula = collection["Matricula"];
                aluno.AnoInicio = Convert.ToInt32(collection["AnoInicio"]);
                aluno.SemestreInicio = Convert.ToInt32(collection["SemestreInicio"]);
                AlunoDAO.Persistir(aluno);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            Aluno aluno = AlunoDAO.BuscarPorId(id);
            if (aluno == null) {
                return HttpNotFound();
            }

            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Aluno aluno= new Aluno();
                aluno.Id = id;
                aluno.Nome = collection["Nome"];
                aluno.Cpf = collection["Cpf"];
                aluno.DataNascimento = Convert.ToDateTime(collection["DataNascimento"]);
                aluno.Email = collection["Email"];
                aluno.Endereco = collection["Endereco"];
                aluno.Telefone = collection["Telefone"];
                aluno.Identidade = collection["Identidade"];
                aluno.Matricula = collection["Matricula"];
                aluno.AnoInicio = Convert.ToInt32(collection["AnoInicio"]);
                aluno.SemestreInicio = Convert.ToInt32(collection["SemestreInicio"]);
                if (!AlunoDAO.Persistir(aluno)) {
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            Aluno aluno = AlunoDAO.BuscarPorId(id);
            if (aluno == null) {
                return HttpNotFound();

            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                AlunoDAO.ExcluirPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
