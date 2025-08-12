using System.ComponentModel.DataAnnotations;

namespace Pokemon_Api.Dto
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<PokemonResponseDto> Pokemon { get; set; }
    }

    public class CategoryCreateRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }

    public class CategoryUpdateRequestDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }
}