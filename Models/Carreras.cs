using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacantesApi.Models
{
    public class Carreras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string NombreCarrera { get; set; }
        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime Creado { get; set; }
        [Required]
        public DateTime Actualizado { get; set; }

        //public ICollection<Habilidades> Habilidades { get; set; }
        //public ICollection<Vacantes> Vacantes { get; set; }

        public Carreras()
        {
            this.Actualizado = DateTime.Now;
        }
    }
}
