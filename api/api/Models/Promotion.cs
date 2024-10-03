namespace api.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }
        public string Name { get; set; }
        public decimal DiscountRate { get; set; }
        public int? Quantity { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsActive
        {
            get
            {
                return StartDate <= DateTime.Now && (EndDate == null || EndDate >= DateTime.Now);
            }
        }
    }
}
