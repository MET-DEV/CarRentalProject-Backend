using System;
using System.Collections.Generic;
using System.Text;

namespace MyCore.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool succes, string message):this(succes)
        {
         
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
