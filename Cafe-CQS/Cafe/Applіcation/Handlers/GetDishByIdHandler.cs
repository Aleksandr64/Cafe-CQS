using Cafe.Applіcation.Mapper;
using Cafe.Applіcation.Queries;
using Cafe.Database.Options;
using Cafe.Domain.DTOs.Dish.Responce;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Cafe.Applіcation.Handlers;

public class GetDishByIdHandler : IRequestHandler<GetDishByIdQuery, GetDishResponse>
{
    private readonly string _connectionString;

    public GetDishByIdHandler(IOptions<ConnectionOptions> options)
    {
        _connectionString = options.Value.DefaultConnection;
    }
    
    public async Task<GetDishResponse> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        await using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
        {
            var sqlQuery = @"
                       SELECT * FROM Dishes
                       WHERE Dishes.Id = @DishId
                       ";
            
            sqlConnection.Open();

            await using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@DishId", request.Id);
                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    return null;
                }

                await reader.ReadAsync();
                var result = reader.MapDishRequestFromSqlDataReader();

                return result;
            }
        }
    }
}