using System.Net;

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace MyCompany.MyFunctions
{
    public class MyFunction1
    {
        private readonly IMyInterface _myInstance;

        public MyFunction1(IMyInterface myInstance)
        {
            _myInstance = myInstance ?? throw new ArgumentNullException(nameof(myInstance));
        }

        [Function("MyFunction1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            logger.LogInformation("=== START ===");

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.WriteString(DateTime.Now.ToString());
            response.WriteString(Environment.NewLine + _myInstance.GetMyMessage());

            logger.LogInformation("=== END ===");

            return response;
        }
    }
}