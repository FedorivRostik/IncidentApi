namespace Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();

        public string? IncidentId { get; set; }
        public Incident? Incident { get; set; }
    }
}
