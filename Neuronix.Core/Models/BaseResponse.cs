namespace Neuronix.Core.Models;

public class BaseResponse<T>
{
    
    public T DataResponse { get; set; }
    public List<DetailResponse> Details { get; set; }
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

