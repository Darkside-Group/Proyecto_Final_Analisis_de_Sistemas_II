using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using VeterinariaFronted.Models;

namespace VeterinariaFronted.Controllers
{
    public class VentasController : Controller
    {
        private readonly HttpClient _httpClient;

        public VentasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api");  // Ajusta la URL base según la configuración de tu API
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/ventas/listar");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ventas = JsonConvert.DeserializeObject<IEnumerable<Venta>>(content);
                return View(ventas);
            }

            return View(new List<Venta>());
        }

        // GET: Ventas/Create
        public async Task<IActionResult> Create()
        {
            // Llama al endpoint de productos en la API
            var productosResponse = await _httpClient.GetAsync("/api/productos/listar");
            if (productosResponse.IsSuccessStatusCode)
            {
                var productos = await productosResponse.Content.ReadFromJsonAsync<IEnumerable<Producto>>();
                ViewBag.Productos = new SelectList(productos, "Id", "Nombre");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error al cargar los productos.");
            }

            return View();
        }


        // POST: Ventas/Create
        [HttpPost]
        public async Task<IActionResult> Create(Venta venta)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ventas/registrar", venta);
            if (response.IsSuccessStatusCode)
            {
                // Redirigir al índice de ventas después de registrar la venta
                return RedirectToAction("Index");
            }

            // Manejar el error y regresar a la vista con un mensaje de error
            var errorMessage = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, errorMessage); // Agregar error al modelo
            return View("Index"); // Regresar a la vista de índice
        }



    }



}
