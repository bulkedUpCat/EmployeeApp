using System.Net.Http;
using System.Threading.Tasks;
using EmployeeApp.Functions.Utilities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace EmployeeApp.Functions.EmployeeDataProcessing;

public static class ChainingFunction
{
    [FunctionName(nameof(HttpStart))]
    public static async Task<HttpResponseMessage> HttpStart(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
        [DurableClient] IDurableOrchestrationClient starter,
        ILogger log)
    {
        var instanceId = await starter.StartNewAsync(nameof(RunOrchestrator));

        log.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);

        return starter.CreateCheckStatusResponse(req, instanceId);
    }
    
    [FunctionName(nameof(RunOrchestrator))]
    public static async Task RunOrchestrator(
        [OrchestrationTrigger] IDurableOrchestrationContext context)
    {
        var jsonFileName = await context.CallActivityWithRetryAsync<string>(
            nameof(ApiCallingFunction.CallApi), FunctionRetryOptions.Options, null);
        
        await context.CallActivityWithRetryAsync(
            nameof(JsonToCsvConverterFunction.Convert), FunctionRetryOptions.Options, jsonFileName);
        
        await context.CallActivityWithRetryAsync(
            nameof(CosmosDbAccessingFunction.SaveToDatabase), FunctionRetryOptions.Options, jsonFileName);
    }
}