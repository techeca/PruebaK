namespace Prueba.Migrations
{
    using Prueba.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Prueba.Models.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Prueba.Models.ProductDbContext context)
        {
            // Verifica si ya existen productos en la base de datos.
            if (!context.Productos.Any())
            {
                // Agrega productos de ejemplo
                context.Productos.AddOrUpdate(
                    p => p.Nombre,

                    new Producto
                    {
                        Nombre = "Producto A",
                        Descripcion = "Descripción del Producto A",
                        Categoria = "Categoría 1",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw311985cd/images/large/26835186.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto B",
                        Descripcion = "Descripción del Producto B",
                        Categoria = "Categoría 2",
                        Imagen = "https://multicentro.vteximg.com.br/arquivos/ids/189180-1000-1000/30107917_1.jpg?v=638578631525970000"
                    },

                    new Producto
                    {
                        Nombre = "Producto C",
                        Descripcion = "Descripción del Producto C",
                        Categoria = "Categoría 1",
                        Imagen = "https://www.lapolar.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw250253b6/images/large/27509983.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto D",
                        Descripcion = "Descripción del Producto D",
                        Categoria = "Categoría 3",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw311985cd/images/large/26835186.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto E",
                        Descripcion = "Descripción del Producto E",
                        Categoria = "Categoría 2",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd114c497/images/large/27360190.jpg?sw=1200&sh=1200&sm=fit"
                    },

                     new Producto
                     {
                         Nombre = "Producto F",
                         Descripcion = "Descripción del Producto F",
                         Categoria = "Categoría 4",
                         Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwce28e131/images/large/27497683.jpg?sw=1200&sh=1200&sm=fit"
                     },

                    new Producto
                    {
                        Nombre = "Producto G",
                        Descripcion = "Descripción del Producto G",
                        Categoria = "Categoría 5",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwfe8284af/images/large/27490654.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto H",
                        Descripcion = "Descripción del Producto H",
                        Categoria = "Categoría 6",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwd492bb5a/images/large/27448631.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto I",
                        Descripcion = "Descripción del Producto I",
                        Categoria = "Categoría 7",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa49c40fd/images/large/27398812.jpg?sw=210&sh=210&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto J",
                        Descripcion = "Descripción del Producto J",
                        Categoria = "Categoría 8",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa49c40fd/images/large/27398812.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto K",
                        Descripcion = "Descripción del Producto K",
                        Categoria = "Categoría 9",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwfe8284af/images/large/27490654.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto L",
                        Descripcion = "Descripción del Producto L",
                        Categoria = "Categoría 10",
                        Imagen = "https://www.lapolar.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw250253b6/images/large/27509983.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto M",
                        Descripcion = "Descripción del Producto M",
                        Categoria = "Categoría 11",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwa49c40fd/images/large/27398812.jpg?sw=210&sh=210&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto N",
                        Descripcion = "Descripción del Producto N",
                        Categoria = "Categoría 12",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwfe8284af/images/large/27490654.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto O",
                        Descripcion = "Descripción del Producto O",
                        Categoria = "Categoría 13",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwfe8284af/images/large/27490654.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto P",
                        Descripcion = "Descripción del Producto P",
                        Categoria = "Categoría 14",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dw311985cd/images/large/26835186.jpg?sw=1200&sh=1200&sm=fit"
                    },

                    new Producto
                    {
                        Nombre = "Producto Q",
                        Descripcion = "Descripción del Producto Q",
                        Categoria = "Categoría 15",
                        Imagen = "https://multicentro.vteximg.com.br/arquivos/ids/189180-1000-1000/30107917_1.jpg?v=638578631525970000"
                    },

                    new Producto
                    {
                        Nombre = "Producto R",
                        Descripcion = "Descripción del Producto R",
                        Categoria = "Categoría 16",
                        Imagen = "https://www.abcdin.cl/dw/image/v2/BCPP_PRD/on/demandware.static/-/Sites-master-catalog/default/dwce28e131/images/large/27497683.jpg?sw=1200&sh=1200&sm=fit"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
