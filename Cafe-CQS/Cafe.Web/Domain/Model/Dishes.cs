using System.ComponentModel.DataAnnotations;

namespace Cafe.Web.Model;

public class Dishes
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
}