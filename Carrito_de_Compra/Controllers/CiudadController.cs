using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class CiudadController : Controller
    {

        // GET: Ciudad
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Ciudad> ciudads = this.repo.GetCiudads();
            return View(ciudads);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Ciudad miCiudad)
        {
            if (ModelState.IsValid)
            {
                Ciudad miciudad = this.repo.CreateCiudad(miCiudad);
                return RedirectToAction("Index");
            }
            return View(miCiudad);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Ciudad miciudad = this.repo.GetCiudad(id);
            return View(miciudad);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Ciudad miCiudad)
        {
            if (ModelState.IsValid)
            {
                Ciudad miciudad = this.repo.EditCiudad(miCiudad.IdCiudad, miCiudad);
                return RedirectToAction("Index");
            }
            return View(miCiudad);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            Ciudad miciudad = this.repo.GetCiudad(id);
            return View(miciudad);
        }

        RepositoryCiudad repo;
        public CiudadController()
        {
            repo = new RepositoryCiudad();
        }
    }
}