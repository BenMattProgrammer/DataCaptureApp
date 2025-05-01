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
        Console.WriteLine(ModelState);
        if (ModelState.IsValid)
        {
            try
            {
                string serialized = System.Text.Json.JsonSerializer.Serialize(userData);

                userData.SerializedJson = serialized;

                _context.UserData.Add(userData);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Data has been saved successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error saving data: {ex.Message}");
            }
        }

        return View("Index", userData);
    }


    [HttpGet]
    public IActionResult ReadData()
    {
        try
        {
            var latestUserData = _context.UserData
                .OrderByDescending(u => u.Id)
                .FirstOrDefault();

            if (latestUserData == null)
            {
                return NotFound("No user data found.");
            }

            return Json(latestUserData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error retrieving data: {ex.Message}");
        }
    }
}
