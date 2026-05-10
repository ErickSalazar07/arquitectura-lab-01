using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace persona_api.Models.Entities
{
    [Table("estudios")]
    public class Estudios
    {
        [Column("id_prof")]
        [Display(Name = "ID Profesión")]
        public int IdProf { get; set; }

        [Column("cc_per")]
        [Display(Name = "Cédula Persona")]
        public int CcPer { get; set; }

        [Column("fecha")]
        [Display(Name = "Fecha")]
        public DateOnly? Fecha { get; set; }

        [StringLength(50)]
        [Column("univer")]
        [Display(Name = "Universidad")]
        public string? Univer { get; set; }

        [ForeignKey("IdProf")]
        public Profesion Profesion { get; set; } = null!;

        [ForeignKey("CcPer")]
        public Persona Persona { get; set; } = null!;
    }
}