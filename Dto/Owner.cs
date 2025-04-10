using System.ComponentModel.DataAnnotations;

namespace Pokemon_Api.Dto
{
    public class OwnerResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public string Country { get; set; }
        public ICollection<PokemonResponseDto> Pokemon { get; set; }
    }

    public class OwnerCreateRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Gym { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

    public class OwnerUpdateRequestDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Gym { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}