using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Converter.Models;
using Converter.Utilities;

namespace Converter.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly LengthUtility _lengthUtility;
    private readonly WeightUtility _weightUtility;
    private readonly TemperatureUtility _temperatureUtility;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _lengthUtility = new LengthUtility();
        _weightUtility = new WeightUtility();
        _temperatureUtility = new TemperatureUtility();
    }


    public IActionResult Index()
    {
        ViewBag.LengthUnits = LengthUtility.LengthFactors.Keys.ToList();
        ViewBag.WeightUnits = WeightUtility.WeightFactors.Keys.ToList();
        ViewBag.TemperatureUnits = new List<string> { "c", "f", "k" };
        return View();

    }

    [HttpPost]
    public IActionResult Convert([FromBody] ConversionRequest request)
    {
        try
        {
            double result = request.Type.ToLower() switch
            {
                "length" => _lengthUtility.Convert(request.Value, request.FromUnit, request.ToUnit),
                "weight" => _weightUtility.Convert(request.Value, request.FromUnit, request.ToUnit),
                "temperature" => _temperatureUtility.Convert(request.Value, request.FromUnit, request.ToUnit),
                _ => throw new ArgumentException("Invalid conversion type")
            };

            return Json(new
            {
                success = true,
                result = result,
                fromUnit = request.FromUnit,
                toUnit = request.ToUnit,
            });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, error = ex.Message });
        }
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}