namespace CreditConveyor.Models
{
    public class CreditApplication
    {
        public Guid Id { get; set; }
        public string Reason { get; set; }
        public decimal Volume { get; set; }
        public decimal ClientIncome { get; set; }
        public Guid CreditProductId { get; set; }
    }
}
