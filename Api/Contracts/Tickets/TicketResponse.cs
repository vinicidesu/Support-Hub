using Domain.Entities;

namespace Api.Contracts.Tickets
{
    public sealed class TicketResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public TicketStatus Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
