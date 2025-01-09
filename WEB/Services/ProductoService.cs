using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WEB.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Configuration;

namespace WEB.Services
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService()
        {
            //Obtiene Url de API desde Web.config
            var baseUrl = ConfigurationManager.AppSettings["APIURL"];
            
            //Se crea instancia HttpClient para realizar solicitudes a la API y se especifíca el tipo esperado (JSON)
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Obtener todos los productos
        public async Task<(List<Producto>, int total)> ObtenerProductosAsync(string nombre = null, string descripcion = null, string categoria = null, string orden = "asc", string ordenPor = "Nombre", int page = 1, int pageSize = 10)
        {
            
            var response = await _httpClient.GetAsync($"producto?nombre={nombre}&descripcion={descripcion}&categoria={categoria}&orden={orden}&ordenPor={ordenPor}&pageNumber={page}&pageSize={pageSize}");

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<(List<Producto>, int total)>(data);
            }

            return (null, 0);
        }

        //Obtener Producto por Id
        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"producto/{id}");
            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Producto>(data);
            }

            return null;
        }

        //Crear Producto
        public async Task<Producto> CrearProductoAsync(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("producto", content);

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Producto>(data);
            }

            return null;
        }

        //Actualizar Producto
        public async Task<Producto> ActualizarProductoAsync(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"producto/{producto.Id}", content);

            if(response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Producto>(data);
            }

            return null;
        }

        public async Task<bool> EliminarProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"producto/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}