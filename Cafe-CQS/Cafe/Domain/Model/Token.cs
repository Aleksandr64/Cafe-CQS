namespace Cafe.Domain.Model;

public class Token
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiredTime { get; set; }
}