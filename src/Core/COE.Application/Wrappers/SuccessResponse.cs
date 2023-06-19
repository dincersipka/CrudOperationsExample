using COE.Application.Abstractions.Wrappers;

namespace COE.Application.Wrappers
{
    public class SuccessResponse<T> : IServiceResponse
    {
        public T Value { get; set; }

        public string Message { get; set; }

        public bool IsSuccess { get; private set; } = true;
    }
}
