using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Prueba.Services
{
    public class ProductoRepository
    {
        private readonly ProductDbContext _context;

        //Constructor para el contexto
        public ProductoRepository(ProductDbContext context)
        {
            _context = context;
        }

        //Obtener Producto por ID
        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        //Obtener todos los Productos
        public async Task<(List<Producto>, int total)> ObtenerProductosAsync(string nombre = null, string descripcion = null, string categoria = null, string orden = "asc", string ordenPor = "Nombre", int pageNumber = 1, int pageSize = 10)
        {
            var query = _context.Productos.AsQueryable();

            // Filtros de búsqueda
            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(p => p.Nombre.Contains(nombre));

            if (!string.IsNullOrEmpty(descripcion))
                query = query.Where(p => p.Descripcion.Contains(descripcion));

            if (!string.IsNullOrEmpty(categoria))
                query = query.Where(p => p.Categoria.Contains(categoria));

            // Orden de productos
            query = query.OrderBy(p => p.Id); 

            if (ordenPor.ToLower() == "nombre")
            {
                query = orden.ToLower() == "desc" ? query.OrderByDescending(p => p.Nombre) : query.OrderBy(p => p.Nombre);
            }
            else if (ordenPor.ToLower() == "categoria")
            {
                query = orden.ToLower() == "desc" ? query.OrderByDescending(p => p.Categoria) : query.OrderBy(p => p.Categoria);
            }

            // Total de productos
            int total = await query.CountAsync();

            // Paginación
            var productos = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (productos, total);
        }

        //Agregar producto
        public async Task<Producto> AgregarProductoAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        //Actualizar producto
        public async Task<Producto> ActualizarProductoAsync(Producto producto)
        {
            try
            {
                var existingProducto = await _context.Productos.FindAsync(producto.Id);
                if (existingProducto == null)
                    throw new Exception("Producto no encontrado.");

                // Actualizar solo las propiedades necesarias
                _context.Entry(existingProducto).CurrentValues.SetValues(producto);
                await _context.SaveChangesAsync();

                return existingProducto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar producto: {ex.Message}");
                throw;
            }
        }

        //Eliminar producto
        public async Task<bool> EliminarProductoAsync(int id)
        {
            var producto = await ObtenerProductoPorIdAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}