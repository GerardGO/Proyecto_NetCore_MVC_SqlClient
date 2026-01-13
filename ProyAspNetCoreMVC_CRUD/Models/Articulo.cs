using System.ComponentModel.DataAnnotations;

namespace ProyAspNetCoreMVC_CRUD.Models
{
    public class Articulo
    {
        //[cod_art][nom_art][uni_med][pre_art][stk_art][eli_art]
        [Display(Name = "Código")]
        public string cod_art { get; set; } = "";

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "Solo se permiten letras")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string nom_art { get; set; } = "";

        [Required(ErrorMessage = "La unidad medida es obligatoria")]
        [Display(Name = "Unidad Medida")]
        public string uni_med { get; set; } = ""; //DropDownList

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio es obligatorio")]
        [DataType(DataType.Currency)]
        [Range(0.01, 1000.00, ErrorMessage = "Precio entre 0.00 y 1000.00")]
        public decimal pre_art { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(1, 1000, ErrorMessage = "Stock entre 1 y 1000")]
        public int stk_art { get; set; }

        [Display(Name = "Habilitado")]
        public string eli_art { get; set; } = "";

        public Articulo()
        {
            stk_art = 10;
        }
    }
}
