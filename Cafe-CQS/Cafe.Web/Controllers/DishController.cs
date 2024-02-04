using Cafe.Web.Commands;
using Cafe.Web.Domain.DTOs;
using Cafe.Web.Services.Interface;
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
        await _dishService.AddNewDish(new AddDishCommand(dishRequest));
        return Ok();
    }
}