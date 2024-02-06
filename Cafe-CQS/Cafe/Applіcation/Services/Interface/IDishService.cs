using Cafe.Applіcation.Commands;
using Cafe.Domain.ResultModels;

namespace Cafe.Applіcation.Services.Interface;

public interface IDishService
{
    public Task<Result<string>> AddNewDish(AddDishCommand addDishRequest);
}