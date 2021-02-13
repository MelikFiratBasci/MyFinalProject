﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string message):this(success)
        {
            message = Message;
        }
        public Result(bool success )
        {
            success = Success; 
        }
        public bool Success { get; }

        public string Message { get; }
    }
}