using ExplicacionWeb.BussisnesLayer;
using ExplicacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExplicacionWeb.Controllers
{
    public class AprendizController : Controller//tiene herencia de controler
    {
        private AprendizBL aprendizBL = new AprendizBL();
        private ProgramaBL programaBL = new ProgramaBL();
        Aprendiz ap = new Aprendiz();

        // GET: Aprendiz
        public ActionResult Index()
        {
            return View(aprendizBL.listar());
        }

        // GET: Aprendiz/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aprendiz/Create
        public ActionResult Create()
        {
            //agrego viebwab
            ViewBag.IdPrograma = new SelectList(programaBL.listar(), "IdPrograma", "nombre");
            return View();
        }

        // POST: Aprendiz/Create
        [HttpPost]
        public ActionResult Create(Aprendiz aprendiz)
        {
            try
            {
                // TODO: Add insert logic here
                aprendizBL.guardar(aprendiz);
                return RedirectToAction("Index");
            }
            catch(Exception )
            {

                return View();
            }
        }

        // GET: Aprendiz/Edit/5
        public ActionResult Edit(int id)
        {
            ap = aprendizBL.buscar(id);
            ViewBag.IdPrograma = new SelectList(programaBL.listar(), "IdPrograma", "nombre");
            return View(ap);
            }

        

        // POST: Aprendiz/Edit/5
        [HttpPost]
        public ActionResult Edit(Aprendiz aprendiz)
        {
            try
            {
                // TODO: Add update logic here
                aprendizBL.actualizar(aprendiz);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Aprendiz/Delete/5
        public ActionResult Delete(int id)
        {
            aprendizBL.eliminar(id);
            return View("Index",aprendizBL.listar());
        }

        // POST: Aprendiz/Delete/5
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
