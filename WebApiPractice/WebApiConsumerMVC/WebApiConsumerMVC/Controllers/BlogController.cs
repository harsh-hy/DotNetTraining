using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WebApiConsumerMVC.Models;

namespace WebApiConsumerMVC.Controllers
{
    public class BlogController : Controller
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl = "https://jsonplaceholder.typicode.com/posts";

        // GET: Fetch Posts
        public async Task<IActionResult> Index()
        {
            List<Post> posts = new List<Post>();

            HttpResponseMessage response = await _client.GetAsync(_baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                posts = JsonSerializer.Deserialize<List<Post>>(data,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<Post>();
            }

            return View(posts);
        }

        // GET: Create Page
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Post
        [HttpPost]
        public async Task<IActionResult> Create(Post newPost)
        {
            string jsonPayload = JsonSerializer.Serialize(newPost);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(_baseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Post created successfully (Fake API)!";
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}