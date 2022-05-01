using CarroCompra1.Models;
using CarroCompra1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string Buscar = null;
            List<Articulo> articulos = this.repo.GetArticulos(Buscar);
            return View(articulos);
        }
        [HttpGet]
        public ActionResult BuscarArticulos(string Buscar)
        {
            List<Articulo> articulos = this.repo.GetArticulos(Buscar);
            return RedirectToAction("ListaArticulo", "Articulo",new { Buscar = Buscar });
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        RepositoryArticulo repo;
        public HomeController()
        {
            repo = new RepositoryArticulo();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}