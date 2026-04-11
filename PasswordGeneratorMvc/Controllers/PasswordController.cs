using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorMvc.Models;
using PasswordGeneratorMvc.Services;
using PasswordGeneratorMvc.ViewModels;

namespace PasswordGeneratorMvc.Controllers
{
    public class PasswordController : Controller
    {
        private readonly PasswordService _service;

        public PasswordController(PasswordService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PasswordEntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _service.Create(new PasswordEntry
            {
                Title = model.Title,
                Login = model.Login,
                WebsiteUrl = model.WebsiteUrl,
                EncryptedPassword = model.Password,
                UserId = "user-1"
            });

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var item = _service.GetById(id);

            if (item == null)
                return RedirectToAction(nameof(Index));

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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _service.Update(new PasswordEntry
            {
                Id = model.Id!,
                Title = model.Title,
                Login = model.Login,
                WebsiteUrl = model.WebsiteUrl,
                EncryptedPassword = model.Password,
                UserId = "user-1"
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