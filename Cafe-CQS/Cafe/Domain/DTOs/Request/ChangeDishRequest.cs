namespace Cafe.Domain.DTOs;

public class ChangeDishRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
}