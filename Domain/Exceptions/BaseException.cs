﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BaseException : Exception
    {
        public int StatusCode { get; }

        protected BaseException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
