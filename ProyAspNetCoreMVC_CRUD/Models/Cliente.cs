using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyAspNetCoreMVC_CRUD.Models
{
    public class Cliente
    {
        //[cod_cli][nom_cli][tel_cli][cor_cli][dir_cli][cred_cli][fec_nac][cod_dist][eli_cli]
        public string cod_cli { get; set; } = ""; //not null

        public string nom_cli { get; set; } = ""; //not null

        public string? tel_cli { get; set; } = ""; //null

        public string? cor_cli { get; set; } = ""; //null

        public string? dir_cli { get; set; } = ""; //null

        public int? cred_cli { get; set; } //null

        public DateTime? fec_nac { get; set; } //null

        public int? cod_dist { get; set; } //DropDownList y null

        public string? eli_cli { get; set; } = ""; //null

        public string? nom_dist { get; set; } = ""; //igual agregar si es null


        public Cliente()
        {
            fec_nac = new DateTime(2001, 7, 28); // para inicializar yyyy/mm/dd
        }
    }
}
