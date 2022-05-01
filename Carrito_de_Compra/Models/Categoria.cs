using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }
        [Required]
        [Column("Categoria")]
        [DisplayName("Categoria")]
        public string NombreCategoria { get; set; }
        [DisplayName("Activo")]
        [Column("Activo")]
        public Boolean Activo { get; set; }
        public virtual ICollection<SubCategoria> SubCategorias { get; set; }
    }
}