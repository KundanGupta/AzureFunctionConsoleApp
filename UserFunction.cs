using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionConsoleApp;

public class UserFunction
{
    private readonly ILogger<UserFunction> _logger;

    public UserFunction(ILogger<UserFunction> logger)
    {
        _logger = logger;
    }

    [Function("GetUserInfo")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Return GetUserInfo Details...");
    }
}