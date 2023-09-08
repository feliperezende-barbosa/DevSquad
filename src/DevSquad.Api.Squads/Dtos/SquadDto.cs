using System.ComponentModel.DataAnnotations;

namespace DevSquad.Api.Squads.Dtos
{
    public record SquadDto
    (
        Guid Id,
        [Required] string Name,
        string DeveloperName
    );

    public record SquadCreateDto
    (
        string Name,
        string DeveloperName
    );

    public record SquadUpdateDto
    (
        string Name,
        string DeveloperName
    );
    
}
