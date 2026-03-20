using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorMvc.Models;
using PasswordGeneratorMvc.Services;

namespace PasswordGeneratorMvc.Controllers;

public class PasswordController : Controller
{
    private readonly PasswordService _service;

    public PasswordController(PasswordService service)
    {
        _service = service;
    }

    // Головна сторінка
    public IActionResult Index()
    {
        var passwords = _service.GetAll();
        return View(passwords);
    }

    // Генерація нового пароля через Ajax
    [HttpPost]
    public IActionResult Generate(string title, string login)
    {
        var newPassword = _service.GeneratePassword(title, login);
        return Json(new { success = true, id = newPassword.Id, title = newPassword.Title, login = newPassword.Login, password = newPassword.EncryptedPassword });
    }

    // Видалення пароля через Ajax
    [HttpPost]
    public IActionResult Delete(string id)
    {
        _service.Delete(id);
        return Json(new { success = true });
    }
}