using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class CarService
{
    private readonly AppDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CarService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Zwraca listę dostępnych samochodów (te, które nie są prywatne).
    /// </summary>
    public IEnumerable<Car> GetAll()
    {
        return _context.Cars.Where(c => !c.IsPrivate).ToList();
    }

    /// <summary>
    /// Dodaje nowy samochód, jeśli użytkownik posiada odpowiednie uprawnienia.
    /// </summary>
    public void Add(Car car)
    {
        // Pobieramy rolę z tokena
        var roleClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role);
        var role = roleClaim?.Value;

        if (role != "Admin" && role != "Wynajmujący")  // Sprawdzamy, czy użytkownik ma odpowiednie uprawnienia
        {
            throw new UnauthorizedAccessException("Nie masz uprawnień do dodawania auta.");
        }

        _context.Cars.Add(car);
        _context.SaveChanges();
    }
}
