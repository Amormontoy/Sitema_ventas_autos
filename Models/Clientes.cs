using System.ComponentModel.DataAnnotations;

namespace Sistema_Venta_Autos.Models
{
    public class Clientes
    {
        [Key][Required(ErrorMessage = "Por favor ingrese DNI")]
        public string codclientes{get; set;}
        [Required(ErrorMessage = "Por favor ingrese Apellido")]
        public string apemat_cli {get; set;}
        [Required(ErrorMessage = "Por favor ingrese Apellido")]
        public string apepat_cli {get; set;}
        [Required(ErrorMessage = "Por favor ingrese Primer Nombre")]
        public string nom1cli {get; set;}
        public string nom2cli {get; set;}
        [Required(ErrorMessage = "Por favor ingrese Telefono")]
        public string telfmovil_cli {get; set;}
        [Required(ErrorMessage = "Por favor ingrese Email")]
        public string email_cli {get; set;}
        public string tipoclientes {get; set;}
        [Required(ErrorMessage = "Por favor ingrese Moneda")]
        public string tipomoneda {get; set;}
    }
}