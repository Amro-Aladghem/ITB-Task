namespace Database.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Level { get; set; }
        public DateOnly DateOfJoined { get; set; }
    }
}
