using Microsoft.Extensions.Configuration;

namespace MyCompany.MyFunctions
{
    public class MyService : IMyInterface
    {
        private readonly IConfiguration _configuration;

        public MyService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GetMyMessage()
        {
            return $"Hello from the implementation of {nameof(MyService)}, with config value: {_configuration["MyConfigKey"]}";
        }
    }
}