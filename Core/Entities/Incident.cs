namespace Core.Entities
{
    public class Incident
    {
        public string Name { get; set; } = Guid.NewGuid().ToString();
        public string? Description { get; set; }

        public IEnumerable<Account> Accounts { get; set; } = new List<Account>();
    }
}
