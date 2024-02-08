namespace Cafe.Domain.DTOs.Dish.Responce;

public class GetDishResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageUrl { get; set; }
}