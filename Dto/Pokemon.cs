using System.ComponentModel.DataAnnotations;

namespace Pokemon_Api.Dto
{
    public class PokemonResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Category { get; set; }
        public string Owner { get; set; }
        public decimal Rating { get; set; }
        public ICollection<ReviewResponseDto> Reviews { get; set; }
    }

    public class PokemonCreateRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }

    public class PokemonUpdateRequestDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}