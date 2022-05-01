using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("Marca")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdMarca")]

        [Required]
        public int IdMarca { get; set; }
        [Required]
        [DisplayName("Marca")]
        [Column("Marca")]
        public string NombreMarca { get; set; }
        [DisplayName("Activo")]
        [Column("Activo")]
        public Boolean Activo { get; set; }
    }
}