using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Sistema_Venta_Autos.Models;
using Sistema_ventas_autos.Models.Dto;

namespace Sistema_Venta_Autos.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(){
            return View();
        }
        
        public IActionResult cotizacion(){
            return View(_context.Autos.ToList());
        }
        [HttpPost]
         public IActionResult cotizacion(String marca,String modelo,String color){
             var auto = from m in _context.Autos
                 select m;

            if (!String.IsNullOrEmpty(marca))
            {
                auto = auto.Where(s => s.marca.Contains(marca) );
            }else if(!String.IsNullOrEmpty(modelo)){
                auto = auto.Where(s => s.modelo.Contains(modelo) );
            }else if(!String.IsNullOrEmpty(color)){
                auto = auto.Where(s => s.color_auto.Contains(color) );
            }
            
            return View(auto.ToList()); 
           
        }
        public IActionResult autos(){
            Console.WriteLine("Autos");
            return View(_context.Autos.ToList());
        }
        [HttpPost]
        public IActionResult cotizacion2(String DNI,String cantidad,String id){
            
            var entity = _context.Autos.FirstOrDefault(item => item.codauto == id);
            var per = _context.clientes.FirstOrDefault(item => item.codclientes == DNI);
            int qAut=int.Parse(cantidad);
            
            Cotizacion c=new Cotizacion();
            
            c.marca=entity.marca;
            c.modelo=entity.modelo;
            c.codclientes=DNI;
            c.precio=(entity.precio*qAut)+"";
            c.color=entity.color_auto;
            c.nombre=per.nom1cli+" "+per.apepat_cli+" "+per.apemat_cli;
            return View(c);
            
        }
        
        public IActionResult cotizacion2(){
            return RedirectToAction("pdf");
        }  
        [HttpPost]
        public IActionResult pdf(){
            return View();
        }          
    }
}