using Carrito_de_Compra.Models;
using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Data
{
    public class ContextData : DbContext
    {
        public ContextData() : base("conexiondata") { }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }


    }
}