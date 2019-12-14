using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Venta_Autos.Models
{
    public class comprobante
    {
        [Key]
        public string codcomprobante{get; set;}
        public string clientes_codclientes{get; set;}
        public string autos_codauto{get; set;}
        public string vendedor_codven{get; set;}
        public string tiendas_codtiendas{get; set;}
        
        [DataType(DataType.Date)]
        public DateTime fecha {get; set;}
        public string tipo_comprobante_codtipocompro{get; set;}
    }
}