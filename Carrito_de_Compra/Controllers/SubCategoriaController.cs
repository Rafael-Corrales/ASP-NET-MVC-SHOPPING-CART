using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class SubCategoriaController : Controller
    {
        // GET: SubCategoria
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<SubCategoria> subcategorias = this.repo.GetSubCategorias();
            return View(subcategorias);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            List<Categoria> categorias = this.repocat.GetCategorias();
            ViewBag.Categorias = categorias;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(SubCategoria subCategoria)
        {
            if (ModelState.IsValid)
            {
                SubCategoria misubcategoria = this.repo.CreateSubcategoria(subCategoria);
                return RedirectToAction("Index");
            }
            List<Categoria> categorias = this.repocat.GetCategorias();
            ViewBag.Categorias = categorias;
            return View(subCategoria);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            List<Categoria> categorias = this.repocat.GetCategorias();
            ViewBag.Categorias = categorias;

            SubCategoria misubcategoria = this.repo.GetSubcategoria(id);
            return View(misubcategoria);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(SubCategoria miSubCategoria)
        {
            if (ModelState.IsValid)
            {
                SubCategoria misubcategoria = this.repo.EditSubcategoria(miSubCategoria.IdSubCategoria, miSubCategoria);
                return RedirectToAction("Index");
            }
            List<Categoria> categorias = this.repocat.GetCategorias();
            ViewBag.Categorias = categorias;
            return View(miSubCategoria);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Detail(int id)
        {
            SubCategoria misubcategoria = this.repo.GetSubcategoria(id);
            return View(misubcategoria);
        }
        RepositorySubCategoria repo;
        RepositoryCategoria repocat;
        public SubCategoriaController()
        {
            repo = new RepositorySubCategoria();
            repocat = new RepositoryCategoria();
        }
    }
}