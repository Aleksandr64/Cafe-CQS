using Cafe.Web.Domain.DTOs;
using MediatR;

namespace Cafe.Web.Commands;

public record AddDishCommand(AddDishRequest addDish) : IRequest;