using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Sistema_Venta_Autos.Models
{
    public class clienteRcs
    {
        [Key]
        public string codclientes{get; set;}
        public string nombre{get; set;}
        public string apePat{get; set;}
        public string apeMat{get; set;}
        public string auto{get; set;}
        public static List<clienteRcs> listarCliente=new List<clienteRcs>();
        
    }
    
}