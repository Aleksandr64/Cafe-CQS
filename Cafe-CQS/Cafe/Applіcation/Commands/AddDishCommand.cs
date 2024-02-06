using Cafe.Domain.DTOs;
using MediatR;

namespace Cafe.Applіcation.Commands;

public record AddDishCommand(AddDishRequest AddDish) : IRequest;