using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CK.Tutorial.GraphQlApi.Common.Model
{
    public class CustomActionResult : IActionResult
    {
        private readonly CustomResultData _resultData = new CustomResultData();

        public CustomActionResult(object data)
        {
            _resultData.Data = data;
            _resultData.StatusCode = HttpStatusCode.Found;
        }

        public CustomActionResult(HttpStatusCode statusCode, string errorMessage, string errorDetailMessage = null)
        {
            _resultData.Data = null;
            _resultData.StatusCode = statusCode;
            _resultData.ErrorMessage = errorMessage;
            _resultData.ErrorDetailMessage = errorDetailMessage;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var serializeData = JsonConvert.SerializeObject(_resultData,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            var objectResult = new ObjectResult(serializeData)
            {
                StatusCode = (int)_resultData.StatusCode
            };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}