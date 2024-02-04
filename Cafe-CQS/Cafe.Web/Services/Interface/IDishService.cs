using Cafe.Web.Commands;
using Cafe.Web.Domain.DTOs;

namespace Cafe.Web.Services.Interface;

public interface IDishService
{
    public Task AddNewDish(AddDishCommand addDishRequest);
}