using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Services;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoService _productoService;

        public ProductoController()
        {
            _productoService = new ProductoService();
        }

        // GET: Productos (todos)
        public async Task<ActionResult> Index(string nombre = null, string descripcion = null, string categoria = null, string orden = "asc", string ordenPor = "Nombre", int page = 1)
        {
            //Cantidad de productos por página
            int pageSize = 10;

            var (productos, total) = await _productoService.ObtenerProductosAsync(nombre, descripcion, categoria, orden, ordenPor, page, pageSize);

            //Calcula cuántas páginas hay
            var totalPages = (int)Math.Ceiling((double)total / pageSize);

            //ViewBag para pasar la información de la paginación
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.TotalProductos = total;

            return View(productos);
        }

        // GET: Producto/Details/1
        public async Task<ActionResult> Details(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public async Task<ActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var nuevoProducto = await _productoService.CrearProductoAsync(producto);
                if (nuevoProducto != null)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Error al crear el producto");
            }

            return View(producto);
        }

        // GET: Producto/Edit/1
        public async Task<ActionResult> Edit(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if(producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/1
        [HttpPost]
        public async Task<ActionResult> Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var productoEditado = await _productoService.ActualizarProductoAsync(producto);
                if(productoEditado != null)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Error al intentar editar el Producto");
            }

            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteProducto(int id)
        {
            await _productoService.EliminarProductoAsync(id);
            
            return RedirectToAction("Index");
        }
    }
}
