namespace EventEase.Services;

public class SessionService
{
    public string? CurrentUserEmail { get; private set; }
    public string? CurrentUserName { get; private set; }

    public bool IsSignedIn
    {
        get { return !string.IsNullOrWhiteSpace(CurrentUserEmail); }
    }

    public void SignIn(string name, string email)
    {
        CurrentUserName = name;
        CurrentUserEmail = email;
    }

    public void SignOut()
    {
        CurrentUserName = null;
        CurrentUserEmail = null;
    }
}
