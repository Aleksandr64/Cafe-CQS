using Cafe.Applіcation.Commands;
using Cafe.Applіcation.Services.Interface;
using Cafe.Domain.DTOs;
using Cafe.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers;

public class DishController : BaseApiController
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }
    [HttpPost]
    public async Task<IActionResult> AddNewDish([FromBody] AddDishRequest dishRequest)
    {
        var result = await _dishService.AddNewDish(new AddDishCommand(dishRequest));
        return this.GetResponse(result);
    }
}