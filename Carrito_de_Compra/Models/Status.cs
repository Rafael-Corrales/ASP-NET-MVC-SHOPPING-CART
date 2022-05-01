using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Carrito_de_Compra.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdStatus")]
        public int IdStatus { get; set; }
        [Required]
        [Column("Status")]
        [DisplayName("Status")]
        public string NombreStatus { get; set; }
    }
}