using System;
namespace JsonValidatorExtensions
{
    public class InvalidJsonResponse
    {
        public int HttpStatusCode { get; set; }
        public object Data { get; set; }

        public InvalidJsonResponse(int httpStatusCode, object data)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Data = data;
        }
    }
}
