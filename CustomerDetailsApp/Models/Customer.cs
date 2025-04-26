namespace CustomerDetailsApp.Models
{
    public class Customer(string name, int age, string postcode, double height, DateTime dateRegistered) : Entity
    {
        public string Name { get; set; } = name;

        public int Age { get; set; } = age;

        public string Postcode { get; set; } = postcode;

        public double Height { get; set; } = height;

        public DateTime DateRegistered { get; set; } = dateRegistered;
    }
}
