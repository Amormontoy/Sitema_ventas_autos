using System.ComponentModel.DataAnnotations;

namespace Sistema_Venta_Autos.Models
{
    public class tiendas
    {
        [Key]
        public string codtiendas {get; set;}
        public string desctiendas{get; set;}
        public string telftiendas{get; set;}

    }
}