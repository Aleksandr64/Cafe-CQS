namespace Cafe.Domain.ResultModels;

public class UnAuthorizedResult<T> : Result<T>
{
    private readonly List<string> _error = new List<string>();
    public UnAuthorizedResult(string error)
    {
        _error.Add(error);
    }

    public override ResultTypesEnum ResultType => ResultTypesEnum.BadRequest;

    public override List<string> Errors => _error;

    public override T Data => default!;
}