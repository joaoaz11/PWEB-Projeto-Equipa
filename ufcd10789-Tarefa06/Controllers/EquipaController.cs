using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ufcd10789_Tarefa06.Models;

namespace ufcd10789_Tarefa06.Controllers
{
    public class EquipaController : Controller
    {
        // GET: EquipaController
        public ActionResult Index()
        {
            List<Equipa> list = new List<Equipa>();
            using(var db = new DataContext())
            {
                list = db.Equipas.OrderByDescending(e => e.Pontos).ThenBy(e => e.Name).ToList();
            }

            ViewBag.List = list;
            return View();
        }

        // GET: EquipaController/Details/5
        public ActionResult Details(int id)
        {
            Equipa equipa = new Equipa();
            using (var db = new DataContext())
            {
                equipa = db.Equipas.Where(e => e.Id.Equals(id)).First();
            }

            ViewBag.Equipa = equipa;
            return View();
        }

        // GET: EquipaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipa equipa)
        {
            try
            {
                using(var db = new DataContext())
                {
                    db.Add(equipa);
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //todo: enviar erro
                return View();
            }
        }

        // GET: EquipaController/Edit/5
        public ActionResult Edit(int id)
        {
            Equipa equipa = new Equipa();
            using (var db = new DataContext())
            {
                equipa = db.Equipas.Where(e => e.Id.Equals(id)).First();
            }

            ViewBag.Equipa = equipa;
            return View();
        }

        // POST: EquipaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Equipa equipa)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Update(equipa);
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //todo: enviar erro
                return View();
            }
        }

        // GET: EquipaController/Delete/5
        public ActionResult Delete(int id)
        {
            Equipa equipa = new Equipa();
            using (var db = new DataContext())
            {
                equipa = db.Equipas.Where(e => e.Id.Equals(id)).First();
            }

            ViewBag.Equipa = equipa;
            return View();
        }

        // POST: EquipaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Equipa equipa)
        {
            try
            {
                using (var db = new DataContext())
                {
                    db.Remove(equipa);
                    db.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //todo: enviar erro
                return View();
            }
        }
    }
}
