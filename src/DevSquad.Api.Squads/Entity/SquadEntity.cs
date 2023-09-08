namespace DevSquad.Api.Squads.Entity
{
    public class SquadEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Developer> Developers { get; set; }
        public string DeveloperName { get; set; }
    }
}
