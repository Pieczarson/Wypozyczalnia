using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly CarService _carService;

    public CarController(CarService carService)
    {
        _carService = carService;
    }

    // Endpoint do pobierania listy samochodów (publiczny)
    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var cars = _carService.GetAll();
            if (cars == null || !cars.Any())
            {
                return NotFound("Brak samochodów w bazie danych.");
            }
            return Ok(cars);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
        }
    }

    // Endpoint do dodawania nowego samochodu (wymaga autoryzacji)
    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] Car car)
    {
        try
        {
            _carService.Add(car);
            return Ok("Samochód dodany");
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Wystąpił błąd: {ex.Message}");
        }
    }
}
