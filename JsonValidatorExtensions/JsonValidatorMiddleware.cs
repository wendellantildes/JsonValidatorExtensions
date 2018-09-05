using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JsonValidatorExtensions
{
    public class JsonValidatorMiddleware
    {
        private const string _jsonContentType = "application/json";
        private readonly RequestDelegate _next;
        private InvalidJsonResponseOptions _options;

        public JsonValidatorMiddleware(RequestDelegate next, InvalidJsonResponseOptions options)
        {
            _next = next;
            _options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            if (context.Request.ContentType != null && context.Request.ContentType == _jsonContentType)
            {
                if (context.Request.Body != null)
                {
                    request.EnableBuffering();

                    var bodyStr = "";
                    using (StreamReader reader
                           = new StreamReader(request.Body))
                    {
                        bodyStr = reader.ReadToEnd();

                    }
                    if (!JsonValidatorTool.JsonValidator.IsValid(bodyStr))
                    {
                        
                        context.Response.StatusCode = _options.HttpStatusCode;
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(_options.Data));
                        return;
                    }
                    context.Request.Body.Position = 0;
                }
            }
            await _next(context);
        }
    }
}
