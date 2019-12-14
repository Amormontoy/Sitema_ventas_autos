using System.ComponentModel.DataAnnotations;

namespace Sistema_Venta_Autos.Models
{
    public class Autos
    {
        public string marca {get; set;}
        public string modelo {get; set;}
        public string anho {get;set;}
        public string cilindrada {get; set;}
        public string color_auto {get;set;}
        [Key]
        public string codauto {get;set;}
        public double precio {get;set;}
        public double pesobruto {get;set;}
        public double altura {get;set;}
        public double ancho {get;set;}
        public double largo {get;set;}
        public char stock {get;set;}
        public int capacidadpers {get;set;}

    }
}