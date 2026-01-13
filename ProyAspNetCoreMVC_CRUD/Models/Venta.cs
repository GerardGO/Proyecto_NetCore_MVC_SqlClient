using System.ComponentModel.DataAnnotations;

namespace ProyAspNetCoreMVC_CRUD.Models
{
    public class Venta
    {
        //[num_vta][fec_vta][cod_cli][cod_ven][tot_vta][anulado]
        [Display(Name = "Nro Venta")]
        public string num_vta { get; set; } = "";

        [Display(Name = "Fec Venta")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fec_vta { get; set; } //solo para el usuario, pq el sp obtiene la fecha del server, no de c#

        [Display(Name = "Cod Cliente")]
        [Required(ErrorMessage = "El cliente es obligatorio")]
        public string cod_cli { get; set; } = ""; //DropDownList

        [Display(Name = "Cod Vendedor")]
        [Required(ErrorMessage = "El vendedor es obligatorio")]
        public int cod_ven { get; set; } //DropDownList, pero debería elegir el que inicia sesión

        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal tot_vta { get; set; } //readonly

        [Display(Name = "Anulado")]
        public string anulado { get; set; } = "";

        public Venta()
        {
            fec_vta = DateTime.Now;
        }
    }
}
