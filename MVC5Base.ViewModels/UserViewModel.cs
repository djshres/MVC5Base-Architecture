namespace MVC5Base.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public RoleViewModel Role { get; set; }
    }
}
