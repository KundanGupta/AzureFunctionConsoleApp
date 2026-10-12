using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionConsoleApp;

public class FunctionDemo
{
    private readonly ILogger<FunctionDemo> _logger;

    public FunctionDemo(ILogger<FunctionDemo> logger)
    {
        _logger = logger;
    }

    [Function("GetAllUsers")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "user/GetAllUsers")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }

    [Function("GetExternalServiceURL")]
    public IActionResult GetExternalServiceURL([HttpTrigger(AuthorizationLevel.Function, "get", Route = "external-service/GetExternalServiceURL")] HttpRequest req)
    {
        var ExternalServiceURL = Environment.GetEnvironmentVariable("SomeExternalService");
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions: " + ExternalServiceURL);
    }
}