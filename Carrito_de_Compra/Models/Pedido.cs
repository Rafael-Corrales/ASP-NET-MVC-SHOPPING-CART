using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("Pedido")]

    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPedido")]
        public long IdPedido { get; set; }

        [Required]
        [Column("IdStatus")]
        public int IdStatus { get; set; }
        [Required]
        [Column("IdUsuario")]
        public string IdUsuario { get; set; }

        [DisplayName("Fecha")]
        [Column("FechaRealizada")]
        public DateTime FechaRealizada { get; set; }

        [DisplayName("Posible fecha de entrega")]
        [Column("FechaEntregaEstimada")]
        public DateTime? FechaEntregaEstimada { get; set; }
        [Required]
        [Column("IdSucursal")]
        public int IdSucursal { get; set; }

        [DisplayName("Subtotal")]
        [Column("SubTotal")]
        public decimal SubTotal { get; set; }
        [DisplayName("Impuesto")]
        [Required]
        [Column("Impuesto")]
        public decimal Impuesto { get; set; }
        [DisplayName("Descuento")]
        [Required]
        [Column("Descuento")]
        public decimal Descuento { get; set; }
        [DisplayName("Total")]
        [Required]
        [Column("Total")]
        public decimal Total { get; set; }

        [Required]
        [DisplayName("Direccion de Envio")]
        [Column("DireccionEnvio")]
        public string DireccionEnvio { get; set; }
        [DisplayName("Correo")]
        [Required]
        [Column("Correo")]
        public string Correo { get; set; }
        [Required]
        [DisplayName("Telefono")]
        [Column("Telefono")]
        public string Telefono { get; set; }
        [DisplayName("Nombre")]
        [Required]
        [Column("Nombre")]
        public string Nombre { get; set; }

        public virtual Sucursal Sucursal { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<DetallePedido> Detalle { get; set; }

    }
}