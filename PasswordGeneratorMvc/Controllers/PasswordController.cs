using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorMvc.Services;
using PasswordGeneratorMvc.Models;
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

        // ===== INDEX =====
        public IActionResult Index()
        {
            var passwords = _service.GetAll();
            return View(passwords);
        }

        // ===== GENERATE =====
        [HttpPost]
        public IActionResult Generate(string title, string login)
        {
            var newPassword = _service.GeneratePassword(title, login);

            return Json(new
            {
                success = true,
                id = newPassword.Id,
                title = newPassword.Title,
                login = newPassword.Login,
                password = newPassword.EncryptedPassword
            });
        }

        // ===== DELETE =====
        [HttpPost]
        public IActionResult Delete(string id)
        {
            _service.Delete(id);
            return Json(new { success = true });
        }

        // ===== CREATE =====
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PasswordEntryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entry = new PasswordEntry
            {
                Title = model.Title,
                Login = model.Login,
                WebsiteUrl = model.WebsiteUrl,
                EncryptedPassword = model.Password,
                Notes = model.Notes,
                UserId = "user-1"
            };

            _service.Create(entry);

            return RedirectToAction("Index");
        }

        // ===== EDIT =====
        public IActionResult Edit(string id)
        {
            var item = _service.GetById(id);

            var vm = new PasswordEntryViewModel
            {
                Id = item.Id,
                Title = item.Title,
                Login = item.Login,
                WebsiteUrl = item.WebsiteUrl,
                Password = item.EncryptedPassword,
                Notes = item.Notes
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(PasswordEntryViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entry = new PasswordEntry
            {
                Id = model.Id!,
                Title = model.Title,
                Login = model.Login,
                WebsiteUrl = model.WebsiteUrl,
                EncryptedPassword = model.Password,
                Notes = model.Notes
            };

            _service.Update(entry);

            return RedirectToAction("Index");
        }
    }
}