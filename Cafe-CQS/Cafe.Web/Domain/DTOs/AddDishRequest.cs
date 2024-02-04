namespace Cafe.Web.Domain.DTOs;

public class AddDishRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
}