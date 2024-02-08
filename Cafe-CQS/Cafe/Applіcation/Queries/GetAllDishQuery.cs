using Cafe.Domain.DTOs.Dish.Responce;
using Cafe.Domain.Model;
using MediatR;

namespace Cafe.Applіcation.Queries;

public record GetAllDishQuery() : IRequest<IEnumerable<GetDishResponse>>;