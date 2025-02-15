using VirtualClassApp.Domain.Abstractions.Entities;

namespace VirtualClassApp.Application.Abstractions.Repositories.Responses;

public record GetAllResponse<T>(IEnumerable<T> Items, int Count) where T : class, IEntity, new();
