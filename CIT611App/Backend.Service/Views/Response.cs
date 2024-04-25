using System;

namespace Backend.Service.Common.Views
{

    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public Response()
        {

        }
        public Response(T data, string message = "", bool isSuccess = true)
        {
            Data = data;
            IsSuccess = isSuccess;
            Message = message;

        }
    }
}
