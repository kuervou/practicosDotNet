using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.EFModels
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Marca { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Modelo { get; set; }

        [MaxLength(128), MinLength(3), Required]
        public string Matricula { get; set; }

        [ForeignKey("PersonaId")]
        public long PersonaId { get; set; }

        public Personas Persona { get; set; }
    }
}
