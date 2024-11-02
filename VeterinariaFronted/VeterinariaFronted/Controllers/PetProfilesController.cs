using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VentaFronted.Models;
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



        public async Task<IActionResult> InfoMascota(int id)
        {
            // Llamada a la API para obtener el perfil de la mascota con observaciones
            var response = await _httpClient.GetAsync($"/api/perfiles-mascotas/{id}/observaciones");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound(); // Manejar el caso cuando no se encuentra el perfil
            }

            var content = await response.Content.ReadAsStringAsync();
            var petProfileWithObservations = JsonConvert.DeserializeObject<PetProfile>(content); // Deserializar la respuesta

            // Llamada a la API para obtener las citas de la mascota
            var citasResponse = await _httpClient.GetAsync($"/api/perfiles-mascotas/{id}/citas");
            if (citasResponse.IsSuccessStatusCode)
            {
                var citasContent = await citasResponse.Content.ReadAsStringAsync();
                petProfileWithObservations.Citas = JsonConvert.DeserializeObject<List<CitaDeMascota>>(citasContent); // Asignar las citas al modelo
            }

            return View(petProfileWithObservations); // Enviar la vista con el modelo
        }


        // POST: /PetProfiles/AgregarObservacion
        // POST: /PetProfiles/AgregarObservacion
        // POST: /PetProfiles/AgregarObservacion
        [HttpPost]
        public async Task<IActionResult> AgregarObservacion(CombinadosInformacionMascota combinados)
        {
            if (ModelState.IsValid)
            {
                // Asignar el PetProfileId a IdPerfilMascota
                combinados.CitaDeMascota.IdPerfilMascota = combinados.PetObservation.PetProfileId;

                // Serializar y enviar el objeto combinado (con observación y cita)
                var jsonRequest = JsonConvert.SerializeObject(new
                {
                    PetProfileId = combinados.PetObservation.PetProfileId,
                    ObservationDate = combinados.PetObservation.ObservationDate,
                    ObservationText = combinados.PetObservation.ObservationText,
                    AppointmentDate = combinados.CitaDeMascota.FechaCita,
                    AppointmentDescription = combinados.CitaDeMascota.Descripcion
                });

                var contentRequest = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("/api/perfiles-mascotas/CrearObservacionesYProximaCita", contentRequest);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("InfoMascota", new { id = combinados.PetObservation.PetProfileId }); // Redirigir a la vista de información de la mascota
                }
                else
                {
                    // Manejar el error, tal vez agregar un mensaje a ModelState
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Error al agregar la observación o la cita: {errorMessage}");
                }
            }

            // Si hay errores, volver a la vista con el modelo adecuado
            return View("InfoMascota", combinados); // Pasar el modelo completo para que la vista tenga toda la información
        }





    }
}
