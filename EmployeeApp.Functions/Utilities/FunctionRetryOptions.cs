using System;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace EmployeeApp.Functions.Utilities;

public static class FunctionRetryOptions
{
    // TODO: Retry only transient failures such as 500, 502, 504 etc
    public static RetryOptions Options = new(
        firstRetryInterval: TimeSpan.FromSeconds(2),
        maxNumberOfAttempts: 3);
}