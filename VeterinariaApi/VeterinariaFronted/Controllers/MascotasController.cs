using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using VeterinariaFronted.Models;

namespace VeterinariaFronted.Controllers
{
    public class MascotasController : Controller
    {
        private readonly HttpClient _httpClient;

        public MascotasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Mascotas/VerMascotasCompleta");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var mascotas = JsonSerializer.Deserialize<IEnumerable<MascotasViewModel>>(content);
                return View("Index", mascotas);
            }
            return View(new List<MascotasViewModel>());
        }
    }
}
