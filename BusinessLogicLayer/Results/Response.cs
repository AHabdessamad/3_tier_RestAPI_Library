using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Results
{
    public class Response<T>
    {
        public bool success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static Response<T> Success(int statusCode = 200, string messsage = null, object data = null) 
        { 
            return new Response<T> 
            {   success = true,
                StatusCode = statusCode, 
                Message = messsage ?? "Success operation", 
                Data = data 
            };
        }

        public static Response<T> Failure(int statusCode = 400, string message = null, object data =null)
        {
            return new Response<T>
            {
                success = false,
                StatusCode = statusCode,
                Message = message ?? "Error occurred",
                Data = data
            };
        }
    }
}
