using Microsoft.AspNetCore.Mvc;

public class ChatController : Controller
{
    private readonly RabbitMqService _rabbitMq;
    private readonly IConfiguration _configuration;

    public ChatController(RabbitMqService rabbitMq, IConfiguration configuration)
    {
        _rabbitMq = rabbitMq;
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.UserName = _configuration["ChatUser"];
        return View();
    }

    [HttpPost]
    [Route("api/chat/send")]
    public IActionResult Send([FromBody] ChatMessage message)
    {
        _rabbitMq.Publish(message);
        return Ok("Message Sent");
    }
    [HttpGet]
    [Route("api/chat/messages")]
    public IActionResult GetMessages()
    {
        return Json(_rabbitMq.ReceivedMessages);
    }
}