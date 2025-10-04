namespace Bootcamp3_AspMVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInHours { get; set; }
        public decimal Price { get; set; }
    }
}
