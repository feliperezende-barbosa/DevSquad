using DevSquad.Api.Squads.Dtos;
using DevSquad.Api.Squads.Entity;

namespace DevSquad.Api.Squads.Extension
{
    public static class Extensions
    {
        public static SquadDto AsDto(this SquadEntity squad)
        {
            return new SquadDto(squad.Id, squad.Name, squad.Description, squad.DeveloperName);
        }
    }
}
