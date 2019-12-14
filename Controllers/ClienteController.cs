using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_Autos.Models;
using System;
using System.Linq;
namespace Sistema_Venta_Autos.Controllers
{
    public class ClienteController :Controller
    {
        private readonly DatabaseContext _context;

        public ClienteController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult cliente_agregar(){
            return View();
        }
        [HttpPost]
        public IActionResult cliente_agregar(Clientes c){
            if(ModelState.IsValid){
                Console.WriteLine("Cliente Agregar");
                _context.Add(c);
                _context.SaveChanges();
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult cliente_eliminar(String DNI){
            
            Console.WriteLine("Cliente Eliminarº"+DNI+"º");
                if(DNI.Equals("Ingrese el DNI a borrar...")||DNI.Equals("")){
                
                }else{

                var clientes = new Clientes { codclientes = DNI };
                _context.Remove(clientes);
                _context.SaveChanges();
                }

             return View(_context.clientes.ToList());
        }
        public IActionResult cliente_eliminar(){
            return View(_context.clientes.ToList()); 
        }
        public IActionResult cliente_revisar(){
            Console.WriteLine("cliente_revisar");
          
            return View(_context.clientes.ToList());
        }
    }
}