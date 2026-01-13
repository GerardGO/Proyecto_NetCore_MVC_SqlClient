using System.ComponentModel.DataAnnotations;

namespace ProyAspNetCoreMVC_CRUD.Models
{
    public class Vendedor
    {
        //[cod_ven][nom_ven][fecing_ven][eli_ven]
        [Display(Name = "Código")]
        public int cod_ven { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string nom_ven { get; set; } = "";

        [Display(Name = "Fec. Ingreso")]
        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecing_ven { get; set; }

        [Display(Name = "Habilitado")]
        public string eli_ven { get; set; } = "";


        public Vendedor()
        {
            fecing_ven = new DateTime(2020/01/01);
        }
    }
}
