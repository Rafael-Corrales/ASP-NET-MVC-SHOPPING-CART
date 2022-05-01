using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Carrito_de_Compra.Models;
using System.ComponentModel;

namespace CarroCompra1.Models
{
    [Table("Articulo")]
    public class Articulo
    {
        // El get y set es para obtener y escribir en los campos de los registros de las tablas
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdArticulo")]
        public int IdArticulo { get; set; }
        [Required]
        [DisplayName("Articulo")]
        [Column("Articulo")]
        public String NombreArticulo { get; set; }

        [Required]
        [DisplayName("Descripción")]
        [Column("Descripcion")]
        public String Descripcion { get; set; }

        [Required]
        [DisplayName("Stock")]
        [Column("Stock")]
        [Range(1, Int32.MaxValue)]
        public int Stock{ get; set; }

        [DisplayName("Características")]
        [Column("Caracteristicas")]
        public string Caracteristicas { get; set; }

        [DisplayName("Url Imagen")]
        [Column("UrlImagen")]
        public String UrlImagen { get; set; }

        [Required]
        [DisplayName("Marca")]
        [Column("IdMarca")]
        public int IdMarca { get; set; }

        [Required]
        [DisplayName("Subcategoria")]
        [Column("IdSubcategoria")]
        public int IdSubCategoria { get; set; }

        [Required]
        [DisplayName("Stock Mínimo")]
        [Column("StockMinimo")]
        [Range(1, Int32.MaxValue)]
        public int StockMinimo { get; set; }
        [DisplayName("Activo")]
        [Column("Activo")]
        public Boolean Activo { get; set; }

        [Required]
        [DisplayName("Precio")]
        [Range(1, Int32.MaxValue)]
        [Column("Precio")]
        public decimal Precio { get; set; }

        // Public virtual Hace referencia a las tablas catalogos
        public virtual Marca Marca { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
    }
}