using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Marca> marcas = this.repo.GetMarcas();
            return View(marcas);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Marca miMarca)
        {
            if (ModelState.IsValid)
            {
                Marca mimarca = this.repo.CreateMarca(miMarca);
                return RedirectToAction("Index");
            }
            return View(miMarca);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Marca mimarca = this.repo.GetMarca(id);
            return View(mimarca);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Marca miMarca)
        {
            if (ModelState.IsValid)
            {
                Marca mimarca = this.repo.EditMarca(miMarca.IdMarca, miMarca);
                return RedirectToAction("Index");
            }
            return View(miMarca);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Detail(int id)
        {
            Marca mimarca = this.repo.GetMarca(id);
            return View(mimarca);
        }

        RepositoryMarca repo;
        public MarcaController()
        {
            repo = new RepositoryMarca();
        }
    }
}