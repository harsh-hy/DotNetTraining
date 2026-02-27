
using Microsoft.AspNetCore.Mvc;
using TodoAppMvc.Models;
using System.Net.Http.Json;
namespace TodoAppMvc.Controllers
{
    //[Authorize]
    public class TodoController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TodoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("TodoApi");

            var response = await client.GetAsync("todos");

            if (!response.IsSuccessStatusCode)
                return View(new List<TodoItem>());

            var todos = await response.Content.ReadFromJsonAsync<List<TodoItem>>();

            return View(todos);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem todo)
        {
            if (!ModelState.IsValid)
                return View(todo);

            var client = _httpClientFactory.CreateClient("TodoApi");

            var response = await client.PostAsJsonAsync("todos", todo);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(todo);
        }
        

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("TodoApi");

            var response = await client.DeleteAsync($"todos/{id}");

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("TodoApi");

            var response = await client.GetAsync($"todos/{id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var todo = await response.Content.ReadFromJsonAsync<TodoItem>();

            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoItem todo)
        {
            if (!ModelState.IsValid)
                return View(todo);

            var client = _httpClientFactory.CreateClient("TodoApi");

            var response = await client.PutAsJsonAsync($"todos/{todo.Id}", todo);

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            return View(todo);
        }
    }
}