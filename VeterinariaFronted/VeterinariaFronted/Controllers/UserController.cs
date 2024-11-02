using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VentaFronted.Models;
using VentaFronted.Models;

namespace VeterinariaFronted.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7111/api/login/"); // URL de la API backend
        }

        // GET: User/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("crear", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al crear el usuario.");
            return View(user);
        }

       
        // GET: User/Index1
        [HttpGet]
        public IActionResult Index1()
        {
            return View(new VentaFronted.Models.LoginRequest { Email = string.Empty, Password = string.Empty }); // Inicializar Email y Password
        }


        [HttpPost]
        public async Task<IActionResult> Login(VentaFronted.Models.LoginRequest loginRequest) // Asegúrate de que esto sea correcto
        {
            if (!ModelState.IsValid)
            {
                return View("Index1", loginRequest);
            }

            var jsonLogin = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("login", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseData);

                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Profile", new { id = user.Id });
            }

            ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            return View("Index1", loginRequest);
        }


        // GET: User/Profile
        [HttpGet]
        public async Task<IActionResult> Profile(int id)
        {
            var response = await _httpClient.GetAsync($"get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseData);
                return View(user);
            }

            return RedirectToAction("Index");
        }

        // GET: User/Logout
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpiar la sesión del usuario
            return RedirectToAction("Index"); // Redirige a Index
        }
    }
}
