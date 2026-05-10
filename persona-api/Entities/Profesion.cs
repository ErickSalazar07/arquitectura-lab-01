using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace persona_api.Models.Entities
{
    [Table("profesion")]
    public class Profesion
    {
        [Key]
        [Column("id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(90)]
        [Column("nom")]
        [Display(Name = "Nombre")]
        public string Nom { get; set; } = null!;

        [Column("des")]
        [Display(Name = "Descripción")]
        public string? Des { get; set; }

        public ICollection<Estudios> Estudios { get; set; } = new List<Estudios>();
    }
}