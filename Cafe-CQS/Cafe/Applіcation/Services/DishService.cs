using Cafe.Applіcation.Commands;
using Cafe.Applіcation.Services.Interface;
using Cafe.Applіcation.Validations;
using Cafe.Domain.ResultModels;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Applіcation.Services;

public class DishService : IDishService
{
    private readonly IMediator _mediator;

    public DishService(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<Result<string>> AddNewDish(AddDishCommand addDishCommand)
    {
     
        var validationResult = await new AddDishValidator().ValidateAsync(addDishCommand.AddDish);
        if (!validationResult.IsValid)
        {
            return new BadRequestResult<string>(validationResult.Errors);
        }
        await _mediator.Send(addDishCommand);
        return new SuccessResult<string>(null);
    }
}