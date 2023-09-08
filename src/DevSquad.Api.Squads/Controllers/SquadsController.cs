using DevSquad.Api.Squads.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DevSquad.Api.Squads.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class SquadsController : ControllerBase
    {
        private static readonly List<SquadDto> Squads = new()
        {
            new SquadDto(Guid.NewGuid(), "Squad 1", "Developer 1"),
            new SquadDto(Guid.NewGuid(), "Squad 2", "Developer 2"),
            new SquadDto(Guid.NewGuid(), "Squad 3", "Developer 3")
        };
            
        [HttpGet]
        public IEnumerable<SquadDto> GetSquads()
        {
            return Squads;
        }

        [HttpGet("{id}")]
        public ActionResult<SquadDto> GetSquad(Guid id)
        {
            var squad = Squads.FirstOrDefault(s => s.Id == id);
            if (squad == null)
            {
                return NotFound();
            }

            return squad;
        }

        [HttpPost]
        public ActionResult<SquadDto> CreateSquad(SquadDto squad)
        {
            Squads.Add(squad);
            return CreatedAtAction(nameof(GetSquad), new {id = squad.Id}, squad);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSquad(Guid id, SquadDto squad)
        {            
            if (id != squad.Id)
            {
                return BadRequest();
            }

            var squadToUpdate = Squads.FirstOrDefault(s => s.Id == id);
            if (squadToUpdate == null)
            {
                return NotFound();
            }

            Squads.Remove(squadToUpdate);
            Squads.Add(squad);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSquad(Guid id)
        {
            var squad = Squads.FirstOrDefault(s => s.Id == id);
            if (squad == null)
            {
                return NotFound();
            }

            Squads.Remove(squad);

            return NoContent();
        }
    }
}