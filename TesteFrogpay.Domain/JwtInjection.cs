namespace TesteFrogpay.Domain;

public class JwtInjection
{
    public String Token { get; set; }
    
    public JwtInjection(string token)
    {
        Token = token;
    }
}