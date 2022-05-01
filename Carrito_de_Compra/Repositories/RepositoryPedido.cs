using Carrito_de_Compra.Data;
using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Repositories
{

    public class RepositoryPedido
    {
        ContextData contexto = new ContextData();
        public List<Pedido> GetPedidos()
        {
            var consulta = contexto.Pedido.ToList();

            return consulta;
        }

        public Pedido GetPedidoCarritoByUser(string usuario)
        {
            var consulta = contexto.Pedido.Where(s => s.IdUsuario == usuario).FirstOrDefault();

            return consulta;
        }

        public Pedido PedidoXID(int id)
        {
            var consulta = from datos in contexto.Pedido
                           where datos.IdPedido == id
                           select datos;
            return consulta.FirstOrDefault();
        }

    }
}