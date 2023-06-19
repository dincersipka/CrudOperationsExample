using COE.Application.Abstractions.Wrappers;

namespace COE.Application.Wrappers
{
    public class ErrorResponse : IServiceResponse
    {
        public string Message { get; set; }

        public bool IsSuccess { get; private set; } = false;

        public ErrorResponse(Exception Ex) 
        {
            Message = Ex.Message;
        }
    }
}
