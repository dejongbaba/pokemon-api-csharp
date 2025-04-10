using System.ComponentModel.DataAnnotations;

namespace Pokemon_Api.Dto
{
    public class ReviewerResponseDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ReviewResponseDto> Reviews { get; set; }
    }

    public class ReviewerCreateRequestDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }

    public class ReviewerUpdateRequestDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
    }
}