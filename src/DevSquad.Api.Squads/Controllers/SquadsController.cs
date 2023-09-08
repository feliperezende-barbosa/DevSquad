using DevSquad.Api.Squads.Dtos;
using DevSquad.Api.Squads.Entity;
using DevSquad.Api.Squads.Extension;
using DevSquad.Api.Squads.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DevSquad.Api.Squads.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class SquadsController : ControllerBase
    {
        private readonly SquadsRepository _repository;


        [HttpGet]
        public async Task<IEnumerable<SquadDto>> GetSquads()
        {
            var squads = await _repository.GetSquadsAsync();
            return squads.Select(squad => squad.AsDto());            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SquadDto>> GetSquad(Guid id)
        {
            var squad = await _repository.GetSquadAsync(id);
            
            if (squad == null)
            {
                return NotFound();
            }

            return squad.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<SquadDto>> CreateSquad(SquadDto squad)
        {
            var createdSquad = new SquadEntity
            {
                Description = squad.Description,
                DeveloperName = squad.DeveloperName,
                Name = squad.Name
            };
            
            await _repository.CreateSquadAsync(createdSquad);
            return CreatedAtAction(nameof(GetSquad), new {id = createdSquad.Id}, createdSquad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSquad(Guid id, SquadDto squad)
        {   
            var existingSquad = await _repository.GetSquadAsync(id);

            if (existingSquad == null)
            {
                return NotFound();
            }

            existingSquad.Description = squad.Description;
            existingSquad.DeveloperName = squad.DeveloperName;
            existingSquad.Name = squad.Name;

            await _repository.UpdateSquadAsync(existingSquad);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquad(Guid id)
        {
            var existingSquad = await _repository.GetSquadAsync(id);

            if (existingSquad == null)
            {
                return NotFound();
            }

            await _repository.DeleteSquadAsync(id);

            return NoContent();
        }
    }
}