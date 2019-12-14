using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Sistema_Venta_Autos.Models
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options){
            
        }
        public DbSet<Autos> Autos { get; set; }
        public DbSet<Clientes> clientes{get; set;}
        public DbSet<historialcompras> historialcompras{get;set;}
        public DbSet<comprobante> comprobante{get; set;}
        public DbSet<tiendas> tiendas{get; set;}
        public DbSet<comprobante> comprobanteBD{get; set;}
    }
}