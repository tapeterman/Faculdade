using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using scaweb.Daos;
using scaweb.Models;

namespace scaweb.Controllers
{
    public class DiarioController : Controller
    {
        // GET: Diario
        public ActionResult Index()
        {
            return View(DiarioDAO.BuscarTodos());
        }

        // GET: Diario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Diario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Diario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Diario/Edit/5
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

        // GET: Diario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Diario/Delete/5
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
