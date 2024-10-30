using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VeterinariaFronted.Models;

namespace VentaFronted.Controllers
{
    public class PetProfilesController : Controller
    {
        private readonly HttpClient _httpClient;

        public PetProfilesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api");
        }

        // GET: PetProfiles
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("/api/perfiles-mascotas/listar"); // Cambiado
            var content = await response.Content.ReadAsStringAsync();
            var profiles = JsonConvert.DeserializeObject<IEnumerable<PetProfile>>(content);
            return View(profiles);
        }

        // GET: PetProfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetProfiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PetProfile petProfile)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(petProfile);
                var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("/api/perfiles-mascotas/crear", httpContent); // Cambiado

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(petProfile);
        }

        // GET: PetProfiles/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"/api/perfiles-mascotas/detalles/{id}"); // Cambiado
            var content = await response.Content.ReadAsStringAsync();
            var petProfile = JsonConvert.DeserializeObject<PetProfile>(content);
            return View(petProfile);
        }

        // POST: PetProfiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PetProfile petProfile)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(petProfile);
                var httpContent = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"/api/perfiles-mascotas/editar/{id}", httpContent); // Cambiado

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(petProfile);
        }

        // GET: PetProfiles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"/api/perfiles-mascotas/detalles/{id}"); // Cambiado
            var content = await response.Content.ReadAsStringAsync();
            var petProfile = JsonConvert.DeserializeObject<PetProfile>(content);
            return View(petProfile);
        }

        // POST: PetProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/perfiles-mascotas/eliminar/{id}"); // Cambiado
            return RedirectToAction(nameof(Index));
        }
    }
}
