using System;

namespace API.Error
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage
                           ?? AddCustomMessage(statusCode);
        }

        
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        private string AddCustomMessage(int statusCode)
        {
            return statusCode switch{

                400 => "Bad Request",
                401 => "Not Authourized",
                404 => "Not Found",
                500 => "Server Error",
                _   => null 

            };
        }

    }
}