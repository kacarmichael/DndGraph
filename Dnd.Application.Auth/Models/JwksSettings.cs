namespace Dnd.Application.Auth.Models;

public class JwksSettings
{
    public string Kty { get; set; }
    public string Alg { get; set; }
    public string Use { get; set; }
    public string Kid { get; set; }
    public string N { get; set; }
    public string E { get; set; }
    public string D { get; set; }
    public string P { get; set; }
    public string Q { get; set; }
    public string DP { get; set; }
    public string DQ { get; set; }
    public string InverseQ { get; set; }
}