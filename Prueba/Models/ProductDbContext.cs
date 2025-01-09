using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Prueba.Models
{
    public class ProductDbContext: DbContext
    {
        public ProductDbContext(): base("name=ProductoDbConnection") { }
        
        public DbSet<Producto> Productos { get; set; }
        
    }
}