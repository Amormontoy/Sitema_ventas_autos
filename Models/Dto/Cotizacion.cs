using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Sistema_ventas_autos.Models.Dto
{
    public class Cotizacion
    {
        public string codclientes{get; set;}
        public string nombre{get; set;}
        public string marca{get; set;}
        public string modelo{get; set;}
        public string precio{get; set;}
        public string color{get; set;}
        public string cantidad{get; set;}

    }
}