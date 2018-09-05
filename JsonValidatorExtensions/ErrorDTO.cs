using Newtonsoft.Json;

namespace JsonValidatorExtensions
{
    internal class ErrorDTO
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
