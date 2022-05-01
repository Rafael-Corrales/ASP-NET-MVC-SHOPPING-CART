using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Sucursal> sucursals = this.repo.GetSucursals();
            return View(sucursals);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

                List<Ciudad> ciudades = this.repoc.GetCiudads();
                ViewBag.Ciudads = ciudades;
                return View();

            }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                Sucursal misucursal = this.repo.CreateSucursal(sucursal);
                return RedirectToAction("Index");
            }
            List<Ciudad> ciudades = this.repoc.GetCiudads();
            ViewBag.Ciudads = ciudades;
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            List<Ciudad> ciudades = this.repoc.GetCiudads();
            ViewBag.Ciudads = ciudades;

            Sucursal misucursal = this.repo.GetSucursal(id);
            return View(misucursal);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Sucursal miSucursal)
        {
            if (ModelState.IsValid)
            {
                Sucursal misucursal = this.repo.EditSucursal(miSucursal.IdSucursal, miSucursal);
                return RedirectToAction("Index");
            }
            List<Ciudad> ciudades = this.repoc.GetCiudads();
            ViewBag.Ciudads = ciudades;
            return View(miSucursal);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Detail(int id)
        {
            Sucursal misucursal = this.repo.GetSucursal(id);
            return View(misucursal);
        }

        RepositorySucursal repo;
        RepositoryCiudad repoc;
        public SucursalController()
        {
            repo = new RepositorySucursal();
            repoc = new RepositoryCiudad();
        }
    }
}