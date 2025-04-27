using Microsoft.AspNetCore.Mvc;
using DataCaptureApp.Models;
using DataCaptureApp.Data;

public class UserDataController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserDataController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var latestUserData = _context.UserData.OrderByDescending(u => u.Id).FirstOrDefault();
        return View(latestUserData);
    }

    [HttpPost]
    public IActionResult SaveData(UserData userData)
    {
        if (ModelState.IsValid)
        {
            _context.UserData.Add(userData);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Data has been saved successfully!";
            return RedirectToAction("Index");
        }

        return View("Index", userData);
    }

    [HttpGet]
    public IActionResult ReadData()
    {
        var latestUserData = _context.UserData.OrderByDescending(u => u.Id).FirstOrDefault();

        return Json(latestUserData);
    }
}
