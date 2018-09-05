using System;
namespace JsonValidatorExtensions
{
    public class InvalidJsonResponseOptions
    {
        public int HttpStatusCode { get; set; }
        public object Data { get; set; }

        public InvalidJsonResponseOptions(int httpStatusCode, object data)
        {
            this.HttpStatusCode = httpStatusCode;
            this.Data = data;
        }
    }
}
