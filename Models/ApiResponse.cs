namespace Pokemon_Api.Models
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse(int code, string message, T data)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ApiResponse(int code, T data) : this(code, GetDefaultMessage(code), data)
        {
        }

        private static string GetDefaultMessage(int code)
        {
            return code switch
            {
                200 => "Success",
                201 => "Created",
                400 => "Bad Request",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => "Unknown Status"
            };
        }
    }
}
