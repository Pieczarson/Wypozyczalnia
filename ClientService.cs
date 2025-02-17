using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

public class ClientService
{
    private readonly AppDbContext _context;
    private readonly UserManager<Client> _userManager;

    public ClientService(AppDbContext context, UserManager<Client> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Zwracamy użytkownika na podstawie klucza (typowo string)
    public Client? GetClientById(string id)
    {
        // Teraz używamy DbSet<Client>
        return _context.Clients.FirstOrDefault(client => client.Id.ToString() == id);
    }




    // Przykładowa metoda aktualizacji salda – rola nie jest już przekazywana
    public async Task UpdateBalanceAsync(string clientId, decimal amount)
    {
        var client = await _userManager.FindByIdAsync(clientId);
        if (client != null)
        {
            client.Balance += amount;
            await _context.SaveChangesAsync();
        }
    }
}
