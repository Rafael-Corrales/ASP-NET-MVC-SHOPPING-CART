using Carrito_de_Compra.Models;
using Carrito_de_Compra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrito_de_Compra.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Cliente")]
        public ActionResult Index()
        {
            List<Pedido> pedidos = this.repo.GetPedidos();
            return View(pedidos);
        }
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Cliente")]
        public ActionResult Ver(int id)
        {
           Pedido pedido = this.repo.PedidoXID(id);
            return View(pedido);
        }

        RepositoryPedido repo;
        public PedidoController()
        {
            repo = new RepositoryPedido();
        }
    }
}