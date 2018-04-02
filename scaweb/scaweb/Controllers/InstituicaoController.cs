using scaweb.Daos;
using scaweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace scaweb.App_Start
{
    public class InstituicaoController : Controller
    {
        // GET: Instituicao
        public ActionResult Index()
        {
            return View(InstituicaoDAO.BuscarTodos());
        }

        // GET: Instituicao/Details/5
        public ActionResult Details(int id)
        {
            Instituicao instituicao = InstituicaoDAO.BuscarPorId(id);
            if(instituicao == null) {
                return HttpNotFound();
            }
            return View(instituicao);
        }

        // GET: Instituicao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                Instituicao instituicao = new Instituicao();
                instituicao.Nome = collection["Nome"];
                instituicao.Cnpj = collection["Cnpj"];
                InstituicaoDAO.Persistir(instituicao);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Instituicao/Edit/5
        public ActionResult Edit(int id)
        {
            Instituicao instituicao = InstituicaoDAO.BuscarPorId(id);
            if (instituicao == null) {
                return HttpNotFound();
            }

            return View(instituicao);
        }

        // POST: Instituicao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Instituicao instituicao = new Instituicao();
                instituicao.Id = id;
                instituicao.Nome = collection["Nome"];
                instituicao.Cnpj = collection["Cnpj"];
                if (!InstituicaoDAO.Persistir(instituicao)) {
                    return View();
                }
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Instituicao/Delete/5
        public ActionResult Delete(int id)
        {
            Instituicao instituicao = InstituicaoDAO.BuscarPorId(id);
            if (instituicao ==null) {
                return HttpNotFound();

            }
            return View(instituicao);
        }

        // POST: Instituicao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                InstituicaoDAO.ExcluirPorId(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
