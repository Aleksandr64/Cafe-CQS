using Cafe.Applіcation.Mapper;
using Cafe.Applіcation.Queries;
using Cafe.Database.Options;
using Cafe.Domain.DTOs.Dish.Responce;
using Cafe.Domain.Model;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Cafe.Applіcation.Handlers;

public class GetAllDishHandler : IRequestHandler<GetAllDishQuery, IEnumerable<GetDishResponse>>
{
    private readonly string _connectionString;

    public GetAllDishHandler(IOptions<ConnectionOptions> options)
    {
        _connectionString = options.Value.DefaultConnection;
    }
    
    public async Task<IEnumerable<GetDishResponse>> Handle(GetAllDishQuery request, CancellationToken cancellationToken)
    {
        List<GetDishResponse> record = new List<GetDishResponse>();

        string sqlStatement = @"SELECT * FROM Dishes";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            
            await using (SqlCommand command = new SqlCommand(sqlStatement, connection))
            {
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!reader.HasRows)
                {
                    return null;
                }

                while (await reader.ReadAsync())
                {
                    record.Add(reader.MapDishRequestFromSqlDataReader());
                }
            }
        }
        return record;
    }
}