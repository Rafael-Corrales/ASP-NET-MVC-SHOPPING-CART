using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Carrito_de_Compra.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCliente")]
        public int IdCliente { get; set; }
        [Required]
        [DisplayName("Nombre")]
        [Column("Nombre")]
        public string Nombre { get; set; }
        [DisplayName("Apellidos")]
        [Column("Apellidos")]
        public string Apellidos { get; set; }
        [DisplayName("Direccion")]
        [Column("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Telefono")]
        [Column("Telefono")]
        public string Telefono { get; set; }
        [DisplayName("Correo")]
        [Column("Correo")]
        public string Correo { get; set; }

    }
}