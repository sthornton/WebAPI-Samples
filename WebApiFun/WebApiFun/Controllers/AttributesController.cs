﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApiFun.Models;

namespace WebApiFun.Controllers
{
    [RoutePrefix("api/custom")]
    public class AttributesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult Weird()
        {
            return Ok(new SimpleResponse("defaultGet"));
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Strange(int id)
        {
            return Ok(new SimpleResponse(id, "byResource"));
        }

        [Route("foo")]
        [HttpDelete]
        public IHttpActionResult Foo()
        {
            return ResponseMessage(
                new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        [Route("bar/{id}")]
        [HttpDelete]
        public IHttpActionResult Bar(int id)
        {
            return Ok(new SimpleResponse(id, "barDelete"));
        }

        [Route("bar/{id}")]
        public IHttpActionResult PostBar(int id)
        {
            return Ok(new SimpleResponse(id, "barPost"));
        }
    }
}