using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Functions.Models;
using EmployeeApp.Functions.Utilities;
using Flurl.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace EmployeeApp.Functions.EmployeeDataProcessing;

public static class ApiCallingFunction
{
    [FunctionName(nameof(CallApi))]
    public static async Task<string> CallApi([ActivityTrigger]  IDurableActivityContext context, ILogger log)
    {
        var employeesEndpointUrl = Environment.GetEnvironmentVariable("ApiUrl") + "employees";
        const string fileName = "employees.json";

        var response = await employeesEndpointUrl
            .GetJsonAsync<IEnumerable<EmployeeModel>>();
        
        JsonFileUtilities.PrettyWrite(response, fileName);

        return fileName;
    }
}