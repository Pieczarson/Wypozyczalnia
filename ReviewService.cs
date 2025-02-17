using System.Collections.Generic;
using System.Linq;

public class ReviewService
{
    private readonly AppDbContext _context;

    public ReviewService(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Pobiera wszystkie recenzje.
    /// </summary>
    public IEnumerable<Review> GetAll()
    {
        return _context.Reviews.ToList();
    }

    /// <summary>
    /// Dodaje nową recenzję.
    /// </summary>
    public void Add(Review review)
    {
        _context.Reviews.Add(review);
        _context.SaveChanges();
    }

    // Można dodać inne metody (np. GetById, Update, Delete)
}
