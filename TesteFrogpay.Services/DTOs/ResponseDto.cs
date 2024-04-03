namespace TesteFrogpay.Services.DTOs;

public class ResponseDto<TEntityResponse>
{
    public ResponseDto(int status, string message)
    {
        Status = status;
        Message = message;
    }

    public ResponseDto(int status, TEntityResponse responseObj)
    {
        Status = status;
        ResponseObj = responseObj;
    }

    public ResponseDto(int status, TEntityResponse responseObj, string message)
    {
        Status = status;
        ResponseObj = responseObj;
        Message = message;
    }

    public int Status { get; set; }
    public TEntityResponse ResponseObj { get; set; }
    public string Message { get; set; }
}