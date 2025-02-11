namespace CreditConveyor.Models
{
    public class CreditApplicationRequest
    {
        public string Reason { get; set; }
        public decimal Volume { get; set; }
        public decimal ClientIncome { get; set; }
        public Guid CreditProductId { get; set; }
    }
}
