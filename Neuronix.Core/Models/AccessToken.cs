namespace Neuronix.Core.Models;

public class AccessToken
{
    public string Token { get; set; }
    public DateTime ExpirationTime { get; set; }
    public string UserId { get; set; }
    public virtual User Client { get; set; }
}