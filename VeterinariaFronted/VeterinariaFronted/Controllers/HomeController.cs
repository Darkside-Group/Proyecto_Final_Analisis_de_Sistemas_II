using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Aseg�rate de incluir esto
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VentaFronted.Models;
using VeterinariaFronted.Models;

namespace VeterinariaFronted.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor; // A�adir IHttpContextAccessor

        public HomeController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor) // Inyectar IHttpContextAccessor
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api");
            _httpContextAccessor = httpContextAccessor; // Asignar a la variable
        }

        // M�todo para obtener la lista de productos
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

        // M�todo para obtener la lista de ventas diarias
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

        // M�todo para obtener el inventario por mes
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

        public async Task<IActionResult> Index()
        {
       
            var userId = _httpContextAccessor.HttpContext.Session.GetString("UserId");

            // L�gica adicional si es necesario

            return View();
        }

        public IActionResult Logout()
        {
            // Limpiar la sesi�n
            HttpContext.Session.Clear();
            return RedirectToAction("loginD", "Productos"); // Redirigir a la p�gina de inicio de sesi�n
        }

    }
}
