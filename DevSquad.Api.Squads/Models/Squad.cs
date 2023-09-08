namespace DevSquad.Api.Squads.Models
{
    public class Squad
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Developer> Developers { get; set; }
    }
}