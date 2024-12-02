using System.ComponentModel.DataAnnotations;

namespace SharedDtos
{
    public record BookDto
    (
        [Required]
        [MaxLength(50)]
        string Title,
        [Required]
        string Author,
        [Required]
        DateTime PublishDate,
        [MaxLength(255)]
        string ISBN,
        [Required]
        int NbrOfCopy
    );
    
}
