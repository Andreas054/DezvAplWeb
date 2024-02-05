namespace MagazinAlimentar.Models.Many_to_Many
{
    public class LocationEmployeeRelation
    {
        public Location Location { get; set; }
        public Guid LocationId { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
