public class RegisterDto
{
    public string Fullname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginDto
{
    public string Fullname { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
