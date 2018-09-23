using System;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JsonValidatorExtensionsExample.Web.NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ExampleController : Controller
    {
        // POST api/values
        [HttpPost]
        public Example Post([FromBody]Example example)
        {
            example.Id = Guid.NewGuid();
            return example;
        }
    }
}
