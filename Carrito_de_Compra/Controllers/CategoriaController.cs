using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Categoria> categorias = this.repo.GetCategorias();
            return View(categorias);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Categoria miCategoria)
        {
            if (ModelState.IsValid)
            {
                Categoria micategoria = this.repo.CreateCategoria(miCategoria);
                return RedirectToAction("Index");
            }
            return View(miCategoria);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Categoria micategoria = this.repo.GetCategoria(id);
            return View(micategoria);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Categoria miCategoria)
        {
            if (ModelState.IsValid)
            {
                Categoria micategoria = this.repo.EditCategoria(miCategoria.IdCategoria, miCategoria);
                return RedirectToAction("Index");
            }
            return View(miCategoria);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            Categoria micategoria = this.repo.GetCategoria(id);
            return View(micategoria);
        }

        RepositoryCategoria repo;
        public CategoriaController()
        {
            repo = new RepositoryCategoria();
        }
    }
}