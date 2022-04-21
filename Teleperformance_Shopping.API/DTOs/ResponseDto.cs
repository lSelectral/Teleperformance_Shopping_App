using System.Text.Json.Serialization;

namespace Teleperformance_Shopping.API.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseDto<T> Success(T Data, int statusCode = 0)
        {
            return new ResponseDto<T> { Data = Data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(int statusCode = 0)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode };
        }

        public static ResponseDto<T> Fail(List<String> errors, int statusCode = 0)
        {
            return new ResponseDto<T> { Data = default(T), Errors = errors, StatusCode = statusCode };
        }

        public static ResponseDto<T> Fail(string error, int statusCode = 0)
        {
            return new ResponseDto<T> { Data = default(T), Errors = new List<string>() { error }, StatusCode = statusCode };
        }
    }
}
