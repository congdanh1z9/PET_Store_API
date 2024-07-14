namespace Domain.Entitys
{
    public class Notification : BaseEntity
    {
        public string? ShopName { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public float? Money { get; set; }
        public string? SellerName { get; set; }
        public string? SellerPhone { get; set; }
        public DateTime? MeetDate { get; set; }
        public int? BuyerId { get; set; }
        public virtual Buyer? Buyer { get; set; }
    }
}
