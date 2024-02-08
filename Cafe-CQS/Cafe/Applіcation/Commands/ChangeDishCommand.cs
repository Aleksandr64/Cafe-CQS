using Cafe.Domain.DTOs;
using MediatR;

namespace Cafe.Applіcation.Commands;

public record ChangeDishCommand(ChangeDishRequest ChangeDishRequest) : IRequest;