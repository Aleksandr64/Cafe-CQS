namespace Cafe.Domain.ResultModels;

public abstract class Result<T>
{
    public abstract T Data { get; }
    public abstract List<string> Errors { get; }
    public abstract ResultTypesEnum ResultType { get; }
}