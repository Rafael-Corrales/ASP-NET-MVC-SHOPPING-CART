using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("SubCategoria")]
    public class SubCategoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdSubCategoria")]
        public int IdSubCategoria { get; set; }
        [Required]
        [DisplayName("Subcategoria")]
        [Column("SubCategoria")]
        public string NombreSubCategoria { get; set; }
        [Required]
        [DisplayName("Categoria")]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }
        [DisplayName("Activo")]
        [Column("Activo")]
        public Boolean Activo { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}