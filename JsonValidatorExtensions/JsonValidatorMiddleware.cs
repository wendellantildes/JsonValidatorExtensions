using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;

namespace JsonValidatorExtensions
{
    public class JsonValidatorMiddleware
    {
        private const string _jsonContentType = "application/json";
        private readonly RequestDelegate _next;
        private InvalidJsonResponse _options;

        public JsonValidatorMiddleware(RequestDelegate next, InvalidJsonResponse options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            var body = request.Body;
            if (context.Request.ContentType != null && context.Request.ContentType == _jsonContentType)
            {
                if (context.Request.Body != null)
                {
                    request.EnableBuffering();
                    var bodyAsText = new StreamReader(context.Request.Body).ReadToEnd();
                    context.Request.Body.Position = 0;
                    if (!JsonValidatorTool.JsonValidator.IsValid(bodyAsText))
                    {
                        context.Response.StatusCode = _options.HttpStatusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(_options.Data));
                        return;
                    }
                }
            }
            await _next(context);
        }
    }
}
