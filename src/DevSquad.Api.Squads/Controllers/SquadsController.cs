using DevSquad.Api.Squads.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSquad.Api.Squads.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class SquadsController : ControllerBase
    {
        public List<Squad> GetSquads()
        {
            return new List<Squad>
            {
                new Squad
                {
                    Id = 1,
                    Name = "Squad 1",
                    Developers = new List<Developer>
                    {
                        new Developer
                        {
                            Id = 1,
                            Name = "Member 1"
                        },
                        new Developer
                        {
                            Id = 2,
                            Name = "Member 2"
                        }
                    }
                },
                new Squad
                {
                    Id = 2,
                    Name = "Squad 2",
                    Developers = new List<Developer>
                    {
                        new Developer
                        {
                            Id = 3,
                            Name = "Member 3"
                        },
                        new Developer
                        {
                            Id = 4,
                            Name = "Member 4"
                        }
                    }
                }
            };
        }
        
    }
}