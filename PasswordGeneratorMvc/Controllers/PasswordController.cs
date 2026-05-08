using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorMvc.Filters;
using PasswordGeneratorMvc.Models;
using PasswordGeneratorMvc.Services;
using PasswordGeneratorMvc.ViewModels;
using System.Security.Claims;

namespace PasswordGeneratorMvc.Controllers
{
    [Authorize] 
    [ServiceFilter(typeof(ControllerLoggingFilter))]
    public class PasswordController : Controller
    {
        private readonly PasswordService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public PasswordController(PasswordService service,
            UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        
        private string GetCurrentUserId()
            => _userManager.GetUserId(User) ?? "unknown";

        public IActionResult Index()
            => View(_service.GetAll());

        [HttpGet]
        [TypeFilter(typeof(ActionLoggingFilter),
            Arguments = new object[] { "CreateGET" })]
        public IActionResult Create() => View();

        [HttpPost]
        [TypeFilter(typeof(ActionLoggingFilter),
            Arguments = new object[] { "CreatePOST" })]
        public IActionResult Create(PasswordEntryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _service.Create(new PasswordEntry
            {
                Title = model.Title,
                Login = model.Login,
                WebsiteUrl = model.WebsiteUrl,
                EncryptedPassword = model.Password,
                UserId = GetCurrentUserId() 
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var item = _service.GetById(id);
            if (item == null) return RedirectToAction(nameof(Index));

            return View(new PasswordEntryViewModel
            {
                Id = item.Id,
                Title = item.Title,
                Login = item.Login,
                WebsiteUrl = item.WebsiteUrl,
                Password = item.EncryptedPassword
            });
        }

        [HttpPost]
        public IActionResult Edit(PasswordEntryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            _service.Update(new PasswordEntry
            {
                Id = model.Id!,
                Title = model.Title,
                Login = model.Login,
                WebsiteUrl = model.WebsiteUrl,
                EncryptedPassword = model.Password,
                UserId = GetCurrentUserId()
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}