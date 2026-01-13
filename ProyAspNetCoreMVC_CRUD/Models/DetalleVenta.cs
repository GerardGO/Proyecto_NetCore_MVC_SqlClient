using System.ComponentModel.DataAnnotations;

namespace ProyAspNetCoreMVC_CRUD.Models
{
    public class DetalleVenta
    {
        //[num_vta][cod_art][cantidad][precio][anulado]
        [Display(Name = "Nro Venta")]
        public string num_vta { get; set; } = ""; //readonly

        [Display(Name = "Cod. Artículo")]
        public string cod_art { get; set; } = ""; //readonly

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        [Range(1, 1000, ErrorMessage = "Elegir entre 1 y 1000")]
        public int cantidad { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal precio { get; set; } //readonly

        [Display(Name = "Anulado")]
        public string anulado { get; set; } = "";
    }
}
