using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebStar.Models;

namespace WebStar.Controllers;

public class FilesController : Controller
{
    private readonly ILogger<FilesController> _logger;

    public FilesController(ILogger<FilesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string directoryPath = "./TextFiles/";
        string [] paths = Directory.GetFiles(directoryPath);
        var fileName = Array.ConvertAll(paths, Path.GetFileName);
        ViewBag.fileName = fileName;

        return View();
    }

    public IActionResult Display(string id)
    {
        string path = $"./TextFiles/{id}";
        ViewData["filePath"] = path;

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
