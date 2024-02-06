namespace Cafe.Domain.Model;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int DishId { get; set; }
    public int OrderId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public Order Order { get; set; }
    public Dish Dish { get; set; }
}