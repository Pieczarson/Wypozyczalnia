using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost]
    [Authorize]
    public IActionResult Create([FromBody] Review review)
    {
        _reviewService.Add(review);
        return Ok("Recenzja dodana");
    }
    
    [HttpGet]
    public IActionResult GetAll() => Ok(_reviewService.GetAll());
}
