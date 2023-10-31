namespace Neuronix.Core.Models;

public class BaseErrorResponse
{
    public List<DetailResponse> Details { get; set; }
    public int ErrorCode { get; set; }
    public bool Successful { get; set; }
    public DetailResponse AddDetailResponse(int Id, String Message)
    {
        DetailResponse err = new DetailResponse();
        err.Id = Id;
        err.Message = Message;
        return err;
    }
    public List<string> errors { get; set; }
}

public class DetailResponse
{
    public int Id { get; set; }
    public string Message { get; set; }
}