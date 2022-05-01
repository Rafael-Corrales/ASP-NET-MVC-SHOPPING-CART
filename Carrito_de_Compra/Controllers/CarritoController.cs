using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            Pedido carrito = this.repo.GetPedidoCarritoByUser(this.User.Identity.Name);
            return View(carrito);
        }

        RepositoryPedido repo;
        public CarritoController()
        {
            repo = new RepositoryPedido();
        }
    }
}