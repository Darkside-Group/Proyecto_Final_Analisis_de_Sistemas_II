using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using VeterinariaFronted.Models;
using OfficeOpenXml;

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

        public async Task<IActionResult> ExportToExcel()
        {
            // Configurar el contexto de licencia para EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Cambia a LicenseContext.Commercial si estás utilizando una licencia comercial

            var response = await _httpClient.GetAsync("/api/ventas/listar");
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("No se pudo obtener datos de ventas.");
            }

            var content = await response.Content.ReadAsStringAsync();
            var ventas = JsonConvert.DeserializeObject<IEnumerable<Venta>>(content);

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Ventas");

                // Establecer encabezados
                worksheet.Cells[1, 1].Value = "Nombre Producto";
                worksheet.Cells[1, 2].Value = "Información";
                worksheet.Cells[1, 3].Value = "Precio";
                worksheet.Cells[1, 4].Value = "Cantidad Vendida";
                worksheet.Cells[1, 5].Value = "Cantidad Actual";
                worksheet.Cells[1, 6].Value = "Fecha de Venta";

                // Agregar los datos
                var row = 2;
                foreach (var item in ventas)
                {
                    worksheet.Cells[row, 1].Value = item.Nombre;
                    worksheet.Cells[row, 2].Value = item.Informacion;
                    worksheet.Cells[row, 3].Value = item.Precio;
                    worksheet.Cells[row, 4].Value = item.CantidadVendida;
                    worksheet.Cells[row, 5].Value = item.CantidadActual;
                    worksheet.Cells[row, 6].Value = item.FechaVenta.ToString("dd/MM/yyyy");
                    row++;
                }

                // Ajustar el ancho de las columnas
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Crear un archivo en memoria
                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Devolver el archivo Excel
                var fileName = "Ventas.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
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
