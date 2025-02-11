using CreditConveyor.Models.Enums;

namespace CreditConveyor.Models
{
    public class CallRequest
    {
        public DateTime AssignmentDate { get; set; }
        public CallResult CallResult { get; set; }
        public bool IsProcessed { get; set; }
    }
}
