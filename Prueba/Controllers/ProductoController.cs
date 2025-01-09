using Newtonsoft.Json;
using Prueba.Models;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Prueba.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly ProductoRepository _productoRepository;

        // Constructor para la instancia del repositorio
        public ProductoController()
        {
            var context = new ProductDbContext();
            _productoRepository = new ProductoRepository(context);
        }

        /// <summary>
        /// Obtiene todos los productos en la base de datos.
        /// </summary>
        // GET: api/productos
        [HttpGet]
        public async Task<IHttpActionResult> GetProductos(string nombre = null, string descripcion = null, string categoria = null, string orden = "asc", string ordenPor = "Nombre", int pageNumber = 1, int pageSize = 10)
        {
            var productos = await _productoRepository.ObtenerProductosAsync(nombre, descripcion, categoria, orden, ordenPor, pageNumber, pageSize);
            return Ok(productos);
        }

        /// <summary>
        /// Obtiene producto según ID entregada.
        /// </summary>
        // GET: api/producto/1
        [HttpGet]
        public async Task<IHttpActionResult> GetProducto(int id)
        {
            var producto = await _productoRepository.ObtenerProductoPorIdAsync(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        /// <summary>
        /// Crea un producto nuevo.
        /// </summary>
        // POST: api/producto
        [HttpPost]
        public async Task<IHttpActionResult> CreateProducto(Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdProducto = await _productoRepository.AgregarProductoAsync(producto);
            return CreatedAtRoute("DefaultApi", new { id = createdProducto.Id }, createdProducto);
        }

        /// <summary>
        /// Actualiza un producto según la ID entregada.
        /// </summary>
        // PUT: api/producto/1
        [HttpPut]
        public async Task<IHttpActionResult> UpdateProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != producto.Id)
                return BadRequest("El ID del producto no coincide.");

            try
            {
                var updatedProducto = await _productoRepository.ActualizarProductoAsync(producto);
                return Ok(updatedProducto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Elimina un producto según la ID entregada.
        /// </summary>
        // DELETE: api/producto/1
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProducto(int id)
        {
            var result = await _productoRepository.EliminarProductoAsync(id);
            if(result)
            {
                return Ok("Producto eliminado correctamente.");
            }

            return NotFound();
        }
    }
}
