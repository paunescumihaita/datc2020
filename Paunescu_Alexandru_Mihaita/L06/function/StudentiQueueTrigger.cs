using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Json;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DATC.Student
{
    public static class StudentiQueueTrigger
    {
        [FunctionName("StudentiQueueTrigger")]
        [return: Table("studenti")]
        public static StudentEntity Run([QueueTrigger("q-paunescu", Connection = "datc_STORAGE")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
            var student = JsonConvert.DeserializeObject<StudentEntity>(myQueueItem);
            return student;
        }
    }
}
