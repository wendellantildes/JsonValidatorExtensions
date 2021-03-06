﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace JsonValidatorExtensions
{
    public static class JsonValidatorMiddlewareExtensions
    {
        private const string _defaultErrorMessage = "Invalid Json";

        public static IApplicationBuilder UseJsonValidator(
            this IApplicationBuilder builder, InvalidJsonResponse options)
        {
            return builder.UseMiddleware<JsonValidatorMiddleware>(options);
        }

        public static IApplicationBuilder UseJsonValidator(
           this IApplicationBuilder builder)
        {
            return builder
                .UseMiddleware<JsonValidatorMiddleware>(
                    new InvalidJsonResponse(StatusCodes.Status400BadRequest,
                                                  new ErrorDTO{
                                                     Message = _defaultErrorMessage
                                                  }));
        }
    }
}
