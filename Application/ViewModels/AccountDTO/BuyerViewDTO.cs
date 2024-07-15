
namespace Application.ViewModels.AccountDTO
{
    public class BuyerViewDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? AccountId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileImage { get; set; }
    }
}
