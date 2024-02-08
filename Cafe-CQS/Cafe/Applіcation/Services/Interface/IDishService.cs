using System.Collections;
using Cafe.Applіcation.Commands;
using Cafe.Applіcation.Queries;
using Cafe.Domain.DTOs.Dish.Responce;
using Cafe.Domain.Model;
using Cafe.Domain.ResultModels;

namespace Cafe.Applіcation.Services.Interface;

public interface IDishService
{
    public Task<Result<string>> AddNewDish(AddDishCommand addDishRequest);
    public Task<Result<IEnumerable<GetDishResponse>>> GetAllDish(GetAllDishQuery getAllDishQuery);
    public Task<Result<GetDishResponse>> GetDishById(GetDishByIdQuery getDishByIdQuery);
}