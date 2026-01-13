using System.ComponentModel.DataAnnotations;

namespace ProyAspNetCoreMVC_CRUD.Models
{
    public class Distrito
    {
        //[cod_dist][nom_dist]
        [Display(Name = "Código")]
        public int cod_dist { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre del distrito es obligatorio")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "El distrito debe tener entre 3 y 35 caracteres")]
        public string nom_dist { get; set; } = "";
    }
}
