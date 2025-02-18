using VirtualClassApp.Application.Abstractions.Repositories.Parameters;

namespace VirtualClassApp.Application.Abstractions.Repositories.Responses;

public record GetAllResponse<T>(
    GetAllParameters GetAllParameters, List<T> Items, int Count);
