using CreditConveyor.Models.Enums;

namespace CreditConveyor.Models
{
    public class Call
    {
        public Guid Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public CallResult CallResult { get; set; }
        public bool IsProcessed { get; set; }
        public List<Operator> Operators { get; set; }
    }
}
