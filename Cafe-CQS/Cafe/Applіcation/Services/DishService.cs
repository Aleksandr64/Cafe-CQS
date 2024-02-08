using System.Collections;
using Cafe.Applіcation.Commands;
using Cafe.Applіcation.Queries;
using Cafe.Applіcation.Services.Interface;
using Cafe.Applіcation.Validations;
using Cafe.Domain.DTOs.Dish.Responce;
using Cafe.Domain.Model;
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

    public async Task<Result<IEnumerable<GetDishResponse>>> GetAllDish(GetAllDishQuery getAllDishQuery)
    {
        var result = await _mediator.Send(getAllDishQuery);
        if (result == null)
        {
            return new BadRequestResult<IEnumerable<GetDishResponse>>("Nothing found in the database");
        }
        return new SuccessResult<IEnumerable<GetDishResponse>>(result);
    }

    public async Task<Result<GetDishResponse>> GetDishById(GetDishByIdQuery getDishByIdQuery)
    {
        var result = await _mediator.Send(getDishByIdQuery);
        return new SuccessResult<GetDishResponse>(result);
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