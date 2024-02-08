using Cafe.Domain.DTOs.Dish.Responce;
using MediatR;

namespace Cafe.Applіcation.Queries;

public record GetDishByIdQuery(int Id) : IRequest<GetDishResponse>;