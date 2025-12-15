using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Tickets
{
    public sealed class CreateTicketRequest
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = default!;

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(100)]
        public DateTime CreatedBy { get; set; }
    }
}
