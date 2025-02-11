namespace CreditConveyor.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public string WorkOfPlace { get; set; }
        public string PhoneNumber { get; set; }
    }
}
