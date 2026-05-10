using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace persona_api.Models.Entities
{
    [Table("telefono")]
    public class Telefono
    {
        [Key]
        [StringLength(15)]
        [Column("num")]
        [Display(Name = "Número")]
        public string Num { get; set; } = null!;

        [Required(ErrorMessage = "El operador es obligatorio")]
        [StringLength(45)]
        [Column("oper")]
        [Display(Name = "Operador")]
        public string Oper { get; set; } = null!;

        [Column("duenio")]
        [Display(Name = "Dueño (CC)")]
        public int Duenio { get; set; }

        [ForeignKey("Duenio")]
        public Persona Persona { get; set; } = null!;
    }
}