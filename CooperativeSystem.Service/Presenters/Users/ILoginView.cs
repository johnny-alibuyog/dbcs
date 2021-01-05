using CooperativeSystem.Service.Models;

namespace CooperativeSystem.Service.Presenters.Users
{
    public interface ILoginView
    {
        string UserID { get; }
        string Password { get; }
        string NewPassword { get; }
        string NewPasswordConfirmation { get; }
        User GetUser();
        Application GetApplication();
    }
}
