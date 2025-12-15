using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.Contracts.Tickets
{
    public sealed class ChangeStatusRequest
    {
        [Required]
        public TicketStatus NewStatus { get; set; } = default!;

        [Required]
        [MaxLength(100)]
        public string UpdatedBy { get; set; } = default!;
    }
}
