using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema_ventas_autos.Models.Dto
{
    public class Compro_Venta
    {   
         public string codcomprobante{get; set;}
        public string tienda_codtienda{get; set;}
        [Key]
        public string clientes_codclientes{get; set;}
        public string autos_codautos{get; set;}
        public string marca{get; set;}
        public string modelo{get; set;}
        public string tipomoneda{get; set;}
        public string vendedor_codven{get; set;}

        [DataType(DataType.Date)]
        public DateTime fecha {get; set;}   
        public string tipo_comprobante_codtipocompro{get; set;}   
        public double precio{get; set;}  
        public static List<Compro_Venta> listarCompro=new List<Compro_Venta>(); 
    }
}