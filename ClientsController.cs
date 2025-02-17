using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/clients")]
[ApiController]
[Authorize] // Dostęp tylko dla zalogowanych użytkowników
public class ClientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientsController(AppDbContext context)
    {
        _context = context;
    }

    
    /// Pobiera listę wszystkich klientów.
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }

    
    /// Pobiera dane konkretnego klienta na podstawie ID.
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(string id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound("Klient nie został znaleziony.");
        }

        return client;
    }

  
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(string id, [FromBody] Client updatedClient)
    {
        if (id != updatedClient.Id)
        {
            return BadRequest("ID klienta nie zgadza się z danymi w żądaniu.");
        }

        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound("Klient nie został znaleziony.");
        }

     
        client.FirstName = updatedClient.FirstName;
        client.LastName = updatedClient.LastName;
        client.Email = updatedClient.Email;

        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent(); // HTTP 204 - brak treści, operacja się powiodła
    }

   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(string id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound("Klient nie został znaleziony.");
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Klient usunięty pomyślnie." });
    }
}
