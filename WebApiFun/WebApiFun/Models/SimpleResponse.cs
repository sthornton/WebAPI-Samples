﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiFun.Models
{
    public class SimpleResponse
    {
        public SimpleResponse()
        {

        }

        public SimpleResponse(string message)
        {
            Message = message;
        }

        public SimpleResponse(int id, string message)
        {
            Id = id;
            Message = message;
        }

        public int? Id { get; set; }
        public string Message { get; set; }
    }
}