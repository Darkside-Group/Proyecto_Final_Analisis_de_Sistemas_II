using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using VeterinariaFronted.Models;

namespace VeterinariaFronted.Controllers
{
    public class ProductosController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductosController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api");  // Asegúrate de ajustar la URL base según tu configuración
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/productos/listar");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var productos = JsonConvert.DeserializeObject<IEnumerable<Producto>>(content);
                return View(productos);
            }

            return View(new List<Producto>());
        }

        // GET: Productos/Detalles/5
        public async Task<IActionResult> Detalles(int id)
        {
            var response = await _httpClient.GetAsync($"/api/productos/detalles/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(content);
                return View(producto);
            }

            return NotFound();
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync("/api/productos/crear", producto);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(producto);
        }
        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"/api/productos/detalles/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(content);
                return View(producto);
            }

            return NotFound();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var response = await _httpClient.PutAsJsonAsync($"/api/productos/editar/{id}", producto);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"/api/productos/detalles/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var producto = JsonConvert.DeserializeObject<Producto>(content);
                return View(producto);
            }

            return NotFound();
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/productos/eliminar/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }


        // GET: Auth/Login
        [HttpGet]
        public IActionResult LoginD()
        {
            return View(); 
        }

        // POST: Auth/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("", "El nombre de usuario y la contraseña son requeridos.");
                return View("loginD");
            }

            var loginRequest = new
            {
                username = Username,
                password = Password
            };

            var response = await _httpClient.PostAsJsonAsync("api/login/login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                // Redirigir a la página principal o a la página de productos después de un inicio de sesión exitoso
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Si el inicio de sesión falla, mostrar el error
                ModelState.AddModelError("", "Usuario o contraseña incorrectos.");
                return View("loginD");
            }
        }

    }


}
