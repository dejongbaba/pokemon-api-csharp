using System.ComponentModel.DataAnnotations;

namespace Pokemon_Api.Dto
{
    public class CountryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<OwnerResponseDto> Owners { get; set; }
    }

    public class CountryCreateRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }

    public class CountryUpdateRequestDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }
}