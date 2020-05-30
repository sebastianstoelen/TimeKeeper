using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TimeKeeper
{
    public static class StartTimer
    {
        [FunctionName("StartTimer")]
        public static IActionResult Run(
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
