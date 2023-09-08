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
            new SquadDto(1, "Squad 1", "Developer 1"),
            new SquadDto(2, "Squad 2", "Developer 2"),
            new SquadDto(3, "Squad 3", "Developer 3")
        };
            
        [HttpGet]
        public IEnumerable<SquadDto> GetSquads()
        {
            return Squads;
        }

        [HttpGet("{id}")]
        public ActionResult<SquadDto> GetSquad(int id)
        {
            var squad = Squads.FirstOrDefault(s => s.Id == id);
            if (squad == null)
            {
                return NotFound();
            }

            return squad;
        }
    }
}