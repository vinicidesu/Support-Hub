namespace Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        public string ChangeStatus(TicketStatus newStatus, string updatedBy)
        {
            Status = newStatus;
            UpdatedAt = DateTime.Now;
            UpdatedBy = updatedBy;

            return "Status changed to " + newStatus;
        }
    }
}
