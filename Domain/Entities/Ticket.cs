using SupportHub.Domain.Exceptions;

namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        private static readonly Dictionary<TicketStatus, HashSet<TicketStatus>> AllowedTransitions = new()
        {
            { TicketStatus.Open, new HashSet<TicketStatus> { TicketStatus.InProgress, TicketStatus.Canceled } },
            { TicketStatus.InProgress, new HashSet<TicketStatus> { TicketStatus.Resolved, TicketStatus.Canceled } },
            { TicketStatus.Resolved, new HashSet<TicketStatus> { TicketStatus.Closed, TicketStatus.Reopened } },
            { TicketStatus.Reopened, new HashSet<TicketStatus> { TicketStatus.InProgress, TicketStatus.Canceled } }
        };

        public void ChangeStatus(TicketStatus newStatus, string updatedBy)
        {
            if (string.IsNullOrWhiteSpace(updatedBy))
                throw new DomainException("UpdatedBy cannot be empty.");

            if (Status == TicketStatus.Closed || Status == TicketStatus.Canceled)
                throw new DomainException("Cannot change status of a closed or canceled ticket.");

            ValidateTransition(newStatus);

            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = updatedBy;

            return;
        }

        public void ValidateTransition(TicketStatus newStatus)
        {
            if (AllowedTransitions.ContainsKey(Status))
            {
                if (!AllowedTransitions[Status].Contains(newStatus))
                    throw new DomainException($"Transition from {Status} to {newStatus} is not allowed.");

                return;
            }
            
            throw new DomainException($"No transitions allowed from status {Status}.");
        }
    }
}
