using DevSquad.Api.Squads.Entity;
using MongoDB.Driver;

namespace DevSquad.Api.Squads.Repository
{
    public class SquadsRepository : ISquadsRepository
    {
        public const string colletionName = "squads";
        private readonly IMongoCollection<SquadEntity> _squads;
        private readonly FilterDefinitionBuilder<SquadEntity> _filterBuilder = Builders<SquadEntity>.Filter;

        public SquadsRepository(IMongoDatabase database)
        {
            _squads = database.GetCollection<SquadEntity>(colletionName);
        }

        public async Task<IReadOnlyCollection<SquadEntity>> GetSquadsAsync()
        {
            return await _squads.Find(_filterBuilder.Empty).ToListAsync();
        }

        public async Task<SquadEntity> GetSquadAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(squad => squad.Id, id);
            return await _squads.Find(filter).SingleOrDefaultAsync();
        }

        public async Task CreateSquadAsync(SquadEntity squad)
        {
            if (squad == null)
            {
                throw new ArgumentNullException(nameof(squad));
            }
            await _squads.InsertOneAsync(squad);
        }

        public async Task UpdateSquadAsync(SquadEntity squad)
        {
            if (squad == null)
            {
                throw new ArgumentNullException(nameof(squad));
            }
            var filter = _filterBuilder.Eq(existingSquad => existingSquad.Id, squad.Id);
            await _squads.ReplaceOneAsync(filter, squad);
        }

        public async Task DeleteSquadAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(squad => squad.Id, id);
            await _squads.DeleteOneAsync(filter);
        }
    }
}
