using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace Carrito_de_Compra.Models
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdSucursal")]
        public int IdSucursal { get; set; }
        [Required]
        [Column("Sucursal")]
        [DisplayName("Sucursal")]
        public string NombreSucursal { get; set; }
        [Required]
        [DisplayName("Dirección")]
        [Column("Direccion")]
        public string NombreDireccion { get; set; }
        [Required]
        [DisplayName("Ciudad")]
        [Column("IdCiudad")]
        public int IdCiudad { get; set; }

        public virtual Ciudad Ciudad { get; set; }
        [DisplayName("Activo")]
        [Column("Activo")]
        public Boolean Activo { get; set; }
    }
}