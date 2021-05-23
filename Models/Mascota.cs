using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcVeterinaria.Models
{
    public class Mascota
    {
        [DisplayName("Id de la mascota")]
        [Required(ErrorMessage = "El Id es  requerido")]
        public int Id { get; set; }

        [DisplayName("Nombre de la mascota")]
        [Required(ErrorMessage = "El Nombre es  requerido")]
        public string Nombre { get; set; }

        [DisplayName("Edad de la mascota")]
        [Required(ErrorMessage = "la Edad es  requerida")]
        [Range(typeof(Int32), "1", "50", ErrorMessage = "La edad debe ser entre 1 y 50 años.")]
        public int Edad { get; set; }

        [DisplayName("Dueño de la mascota")]
        [Required(ErrorMessage = "El Dueño de la mascota es  requerido")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",ErrorMessage = "  El {0} Solo permite letras.")]
        [StringLength(50, ErrorMessage = " El {0} de contenener entre {2} y {1}  caracteres.", MinimumLength = 2)]
        public string Dueño { get; set; }
    }
}