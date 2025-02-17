public class Review
{
    public int Id { get; set; }
    public int CarId { get; set; }
    
    public string Comment { get; set; }
    public int Rating { get; set; } // Zakres od 1 do 5
    public string ReviewerName { get; set; }

    public Car? Car { get; set; } // Opcjonalne

    public Review(int carId, string comment, int rating, string reviewerName)
    {
        CarId = carId;
        Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        Rating = rating;
        ReviewerName = reviewerName ?? throw new ArgumentNullException(nameof(reviewerName));
    }
}
