using System.ComponentModel.DataAnnotations;
namespace Sistema_Venta_Autos.Models
{
    public class historialcompras
    {   
        [Key]
        public string clientes_codclientes{get;set;}
        public string autos_codauto{get;set;}
    }
}
