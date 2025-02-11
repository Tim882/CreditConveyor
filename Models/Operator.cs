using CreditConveyor.Models.Enums;

namespace CreditConveyor.Models
{
    public class Operator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Call> Calls { get; set; }
    }
}
