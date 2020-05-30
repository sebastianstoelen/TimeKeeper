using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace TimeKeeper
{
    public static class StartTimer
    {
        [FunctionName("StartTimer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogDebug("StartTimer function has been called.");

            Timer timer = new Timer($"timer-{Guid.NewGuid()}")
            {
                startTime = DateTime.Now
            };

            string response = $"Timer {timer.ToJson()} created.";

            return new OkObjectResult(response);
        }
    }
}
