using Microsoft.AspNetCore.Mvc;
using Sistema_Venta_Autos.Models;
using Sistema_ventas_autos.Models.Dto;
using System;
using System.Linq;

namespace Sistema_Venta_Autos.Controllers
{
    public class VentasController : Controller
    {
        private readonly DatabaseContext _context;

        public VentasController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult comprobante(String tienda,String cliente,String codAuto,String moneda){
            Console.WriteLine("Comprobante");
            if(ModelState.IsValid){
                Console.WriteLine("se queda");
            Compro_Venta com=new Compro_Venta();
            int cod=1;
            
            foreach (var item in _context.comprobanteBD)
            {
                cod++;
            }
            foreach(var c in _context.Autos){
                Console.WriteLine("A:"+codAuto+"."+c.codauto+".");
                if(codAuto.Equals(c.codauto)){                   
                    com.marca=c.marca+"";
                    com.modelo=c.modelo+"";
                    com.precio=c.precio;  
                }
            }
            com.tipomoneda=moneda;
            com.codcomprobante=cod+"";
            com.clientes_codclientes=cliente;
            com.autos_codautos=codAuto;
            com.vendedor_codven=User.Identity.Name;
            Console.WriteLine("________"+com.vendedor_codven);
            com.tienda_codtienda=tienda;
            com.fecha=DateTime.Now;
            Console.WriteLine("B:"+com.codcomprobante+".  ."+com.clientes_codclientes+".");
            
            return View(com);
            }
            return RedirectToAction("venta"); 
        } 
        [HttpPost]
        public IActionResult comprobanteeee(String codCompro,String codTienda,String codven,String codCli,String codauto,String tip,String marca,String modelo,String precio,String TipComp){
          if(ModelState.IsValid){
            Console.WriteLine("COmprobanteeeeHTTP");
            comprobante c=new comprobante();
            historialcompras hc = new historialcompras();
            //Autos a = new Autos();
            c.codcomprobante=codCompro;
            c.clientes_codclientes=codCli;
            c.autos_codauto=codauto;
            c.vendedor_codven=codven;
            c.tiendas_codtiendas=codTienda;
            c.fecha=DateTime.Now;
            c.tipo_comprobante_codtipocompro=TipComp;
            Console.WriteLine("cod:"+c.codcomprobante);
            hc.autos_codauto=codauto;
            hc.clientes_codclientes=codCli;

            _context.Add(c);
            _context.Add(hc);
            
            _context.SaveChanges();
            var entity = _context.Autos.FirstOrDefault(item => item.codauto == codauto);
             if (entity != null)
            {
            entity.stock ='N' ;

            
            _context.Autos.Update(entity);

            
            _context.SaveChanges();
            }
             return RedirectToAction("okPage");
          }else{
              return RedirectToAction("wrongPage");
          }
        }
            
        public IActionResult okPage(){
            return View();
        }
        
       
        public IActionResult venta(){
            Console.WriteLine("venta");
            //return RedirectToAction("comprobante"); 
            return View(_context.tiendas.ToList());
        }

        public IActionResult historial_ventas(){
            Console.WriteLine("historial_ventas");
            clienteRcs clienteR=new clienteRcs();
            clienteRcs.listarCliente.RemoveRange(0,clienteRcs.listarCliente.Count);
            String cod;
            foreach (var item1 in _context.historialcompras)
            {
                Console.WriteLine("AUTO__________________"+item1.autos_codauto);
            }
            foreach (var hc in _context.historialcompras){
                    cod=hc.clientes_codclientes;
                    Console.WriteLine("DNI a buscar"+cod);
                    clienteRcs clienteRC=new clienteRcs();
                    Console.WriteLine("AUTO__________________"+hc.autos_codauto);
                    clienteRC.auto=hc.autos_codauto;
                foreach(var T in _context.clientes){
                    
                    Console.WriteLine("entra");   
                    if(T.codclientes.Equals(cod)){ 
                        Console.WriteLine("SE IMPRIME PRRO"+cod+"       buscar="+T.codclientes);       
                        clienteRC.codclientes=cod;
                        clienteRC.nombre=T.nom1cli;
                        clienteRC.apePat=T.apepat_cli;
                        clienteRC.apeMat=T.apemat_cli;
                        clienteRcs.listarCliente.Add(clienteRC); 
                    }
                  
                }
                

                 
            }
            
            var lista=clienteRcs.listarCliente.ToList();
            
            return View(lista);
        }       
    }
}