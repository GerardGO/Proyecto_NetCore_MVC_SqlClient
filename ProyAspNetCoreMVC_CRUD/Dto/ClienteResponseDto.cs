using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyAspNetCoreMVC_CRUD.Dto
{
    public class ClienteResponseDto
    {
        //[cod_cli][nom_cli][tel_cli][cor_cli][dir_cli][cred_cli][fec_nac][cod_dist][eli_cli]
        [Display(Name = "Código")]
        public string cod_cli { get; set; } = ""; //not null

        [Display(Name = "Nombre")]
        public string nom_cli { get; set; } = ""; //not null

        [Display(Name = "Celular")]
        [DisplayFormat(NullDisplayText = "Sin teléfono")] 
        public string? tel_cli { get; set; } = ""; //null

        [Display(Name = "Correo")]
        [DisplayFormat(NullDisplayText = "Sin correo electrónico")] 
        [EmailAddress(ErrorMessage = "Formato de correo inválido")] 
        public string? cor_cli { get; set; } = ""; //null

        [Display(Name = "Dirección")]
        [DisplayFormat(NullDisplayText = "Sin dirección")]
        public string? dir_cli { get; set; } = ""; //null

        [Display(Name = "Crédito")]
        [DataType(DataType.Currency)]
        public int? cred_cli { get; set; } //null

        [Display(Name = "Fec Nacimiento")]
        [DataType(DataType.Date)] 
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}", NullDisplayText = "Sin fecha nacimiento")] 
        public DateTime? fec_nac { get; set; } //null

      

        [Display(Name = "Distrito")]
        [Required(ErrorMessage = "El distrito es obligatorio")]
        public int? cod_dist { get; set; } 

        [Display(Name = "Deshabilitado")]
        public string? eli_cli { get; set; } = ""; //null

        [NotMapped]
        [Display(Name = "Distrito")]
        public string? nom_dist { get; set; } = ""; //igual agregar si es null
    }
}
