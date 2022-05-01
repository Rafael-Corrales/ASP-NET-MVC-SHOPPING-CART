using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCiudad")]
        public int IdCiudad { get; set; }
        [Required]
        [DisplayName("Ciudad")]
        [Column("Ciudad")]
        public string NombreCiudad { get; set; }
        [DisplayName("Activo")]
        [Column("Activo")]
        public Boolean Activo { get; set; }
    }
}