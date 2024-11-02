using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using VentaFronted.Models;
using VeterinariaFronted.Models;

namespace VeterinariaFronted.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api");
        }






        // Método para obtener la lista de productos
        public async Task<IActionResult> Productos()
        {
            var response = await _httpClient.GetAsync("/Productos");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<IEnumerable<Producto>>(content);
                return View(productos);
            }
            return View(new List<Producto>());
        }

        // Método para obtener la lista de ventas diarias
        public async Task<IActionResult> VentasDiarias()
        {
            var response = await _httpClient.GetAsync("/VentasDiarias");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ventasDiarias = JsonConvert.DeserializeObject<IEnumerable<VentasDiarias>>(content);
                return View(ventasDiarias);
            }
            return View(new List<VentasDiarias>());
        }

        // Método para obtener el inventario por mes
        public async Task<IActionResult> InventarioPorMes()
        {
            var response = await _httpClient.GetAsync("/InventarioPorMes");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var inventario = JsonConvert.DeserializeObject<IEnumerable<InventarioPorMes>>(content);
                return View(inventario);
            }
            return View(new List<InventarioPorMes>());
        }

        // GET: Productos/Login
        public IActionResult loginD()
        {
            return View();
        }

       

        public async Task <IActionResult> Index()
        {
            return View();
        }
    }
}
