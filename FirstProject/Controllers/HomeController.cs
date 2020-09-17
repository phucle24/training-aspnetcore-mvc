using FirstProject.Data;
using FirstProject.Models;
using FirstProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IFirstRepository _repository;
        private readonly FirstContext _context;
        public HomeController(IMailService mailService, IFirstRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            //var results = _context.Products.ToList();
            return View();
        }
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }
        [HttpPost("Privacy")]
        public IActionResult Privacy(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send Email
                _mailService.SendMessage("levanphuc@gmail.com", $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
