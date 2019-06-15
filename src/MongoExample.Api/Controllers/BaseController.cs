using Microsoft.AspNetCore.Mvc;
using MongoExample.Api.Controllers.Attributes;
using MongoExample.CrossCutting.DependencyResolver;
using System;
using System.Net;

namespace MongoExample.Api.Controllers
{
    [ExceptionFilter]
    public class BaseController : ControllerBase
    {
        protected readonly IFactory factory;

        public BaseController(IFactory factory)
        {
            this.factory = factory;
        }

        protected virtual IActionResult CreateResponse(HttpStatusCode httpStatusCode, object response)
        {
            return StatusCode(httpStatusCode.GetHashCode(), response);
        }

        protected virtual IActionResult CreateResponse(HttpStatusCode httpStatusCode)
        {
            return StatusCode(httpStatusCode.GetHashCode());
        }

        protected virtual IActionResult InternalServerError(Exception exception = null)
        {
            return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), exception);
        }
    }
}
