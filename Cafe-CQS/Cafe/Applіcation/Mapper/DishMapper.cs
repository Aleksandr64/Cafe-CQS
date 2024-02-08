using Cafe.Domain.DTOs.Dish.Responce;
using Cafe.Domain.Model;
using Microsoft.Data.SqlClient;

namespace Cafe.Applіcation.Mapper;

public static class DishMapper
{
    public static GetDishResponse MapDishRequestFromSqlDataReader(this SqlDataReader reader)
    {
        return new GetDishResponse()
        {
            Id = (int)reader["Id"],
            Title = (string)reader["Title"],
            Description = (string)reader["Description"],
            Price = (double)(decimal)reader["Price"],
            ImageUrl = (string)reader["ImageUrl"]
        };
    } 
}