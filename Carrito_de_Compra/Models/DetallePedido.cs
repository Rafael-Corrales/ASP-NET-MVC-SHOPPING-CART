using CarroCompra1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("DetallePedido")]
    public class DetallePedido
    {
        [Key, Column("IdPedido", Order = 0)]
        public long IdPedido { get; set; }
        [Required]

        [Key, Column("IdArticulo", Order = 1)]
        public int IdArticulo { get; set; }
        [Required]

        [Column("Cantidad")]
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }
        [Required]
        [Column("Subtotal")]
        [DisplayName("Subtotal")]
        public decimal Subtotal { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}