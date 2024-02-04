using Cafe.Web.Commands;
using Cafe.Web.Domain.DTOs;
using Cafe.Web.Services.Interface;
using MediatR;

namespace Cafe.Web.Services;

public class DishService : IDishService
{
    private readonly IMediator _mediator;

    public DishService(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task AddNewDish(AddDishCommand addDish)
    {
        await _mediator.Send(addDish);
    }
}