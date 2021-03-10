using Newtonsoft.Json;

namespace Core.Extensions
{
    public partial class ExceptionMiddleware
    {
        public class ErrorDetails
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }

            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    }
}