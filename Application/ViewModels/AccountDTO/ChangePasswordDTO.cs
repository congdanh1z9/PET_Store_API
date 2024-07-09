namespace Application.ViewModels.AccountDTO
{
    public class ChangePasswordDTO
    {
        public string email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
