using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyAspNetCoreMVC_CRUD.Dto
{
    public class ClienteRequestDto
    {
        [Display(Name = "Código")]
        public string cod_cli { get; set; } = ""; 

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s,]+$", ErrorMessage = "Solo se permiten letras, espacios y comas.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string nom_cli { get; set; } = ""; 

        [Display(Name = "Celular")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Solo se permiten números")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "El teléfono debe tener 9 dígitos")]
        public string? tel_cli { get; set; } = ""; 

        [Display(Name = "Correo")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "El correo debe tener entre 6 y 50 caracteres")]
        [EmailAddress(ErrorMessage = "Formato de correo inválido")]
        public string? cor_cli { get; set; } = ""; 

        [Display(Name = "Dirección")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9\s,.]+$", ErrorMessage = "Solo letras, números, comas y puntos")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "La dirección debe tener entre 5 y 50 caracteres")]
        public string? dir_cli { get; set; } = ""; 

        [Display(Name = "Crédito")]
        [Range(0.00, 10000.00, ErrorMessage = "Crédito entre 0.00 y 10000.00")]
        public int? cred_cli { get; set; } //null

        [Display(Name = "Fec Nacimiento")]
        [DataType(DataType.Date)] //necesario en response y en request
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "Sin fecha nacimiento")] 
        public DateTime? fec_nac { get; set; } //null

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "El distrito es obligatorio")]
        public int? cod_dist { get; set; } //DropDownList y null

        public ClienteRequestDto()
        {
            fec_nac = new DateTime(2001, 1, 15); // para inicializar yyyy/mm/dd
        }
    }
}
