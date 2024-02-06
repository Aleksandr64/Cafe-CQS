namespace Cafe.Domain.Model;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string EmailAddress { get; set; }
    public double TotalAmount { get; set; }
    public int UserId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }


    public User User { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}