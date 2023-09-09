using DevSquad.Api.Squads.Entity;

namespace DevSquad.Api.Squads.Repository
{
    public interface ISquadsRepository
    {
        Task CreateSquadAsync(SquadEntity squad);
        Task DeleteSquadAsync(Guid id);
        Task<SquadEntity> GetSquadAsync(Guid id);
        Task<IReadOnlyCollection<SquadEntity>> GetSquadsAsync();
        Task UpdateSquadAsync(SquadEntity squad);
    }
}