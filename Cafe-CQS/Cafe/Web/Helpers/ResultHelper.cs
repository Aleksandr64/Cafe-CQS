using Cafe.Domain.ResultModels;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Helpers;

public static class ResultHelper
{
    public static ActionResult GetResponse<T>(this ControllerBase controller, Result<T> result)
    {
        return result.ResultType switch
        {
            ResultTypesEnum.Success => result.Data == null ? controller.NoContent() : controller.Ok(result.Data),
            ResultTypesEnum.BadRequest => controller.BadRequest(result.Errors),
            ResultTypesEnum.NotFound => controller.NotFound(result.Errors),
            ResultTypesEnum.UnAuthorized => controller.Unauthorized(result.Errors),
            _ => controller.BadRequest()
        };
    }
}