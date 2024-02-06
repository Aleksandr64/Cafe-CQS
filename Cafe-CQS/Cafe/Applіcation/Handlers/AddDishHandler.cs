using Cafe.Applіcation.Commands;
using Cafe.Database.Options;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Cafe.Applіcation.Handlers;

public class AddDishHandler : IRequestHandler<AddDishCommand>
{
    private readonly string _connectionString;

    public AddDishHandler(IOptions<ConnectionOptions> options)
    {
        _connectionString = options.Value.DefaultConnection;
    }

    public async Task Handle(AddDishCommand request, CancellationToken cancellationToken)
    {
        var addDishRequest = request.AddDish;
        await using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sqlQuery = @"
            INSERT INTO Dishes (Title, Description, Price, ImageUrl, CreateDateTime, UpdateDateTime)
            VALUES (@Title, @Description, @Price, @ImageUrl, GETDATE(), GETDATE());
            ";

            await using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
            {
                cmd.Parameters.AddWithValue("@Title", addDishRequest.Title);
                cmd.Parameters.AddWithValue("@Description", addDishRequest.Description);
                cmd.Parameters.AddWithValue("@Price", addDishRequest.Price);
                cmd.Parameters.AddWithValue("@ImageUrl", addDishRequest.ImageUrl);

                cmd.ExecuteNonQuery();
            }
        }
    }
}