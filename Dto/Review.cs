using System.ComponentModel.DataAnnotations;

namespace Pokemon_Api.Dto
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public string PokemonName { get; set; }
        public string ReviewerName { get; set; }
    }

    public class ReviewCreateRequestDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Text { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }
    }

    public class ReviewUpdateRequestDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Text { get; set; }

        [Required]
        [Range(1, 10)]
        public int Rating { get; set; }
    }
}