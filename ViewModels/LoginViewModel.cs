using System.ComponentModel.DataAnnotations;

namespace Sistema_ventas_autos.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}