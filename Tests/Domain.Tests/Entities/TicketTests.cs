using Domain.Entities;
using SupportHub.Domain.Exceptions;

namespace Domain.Tests.Entities
{
    public class TicketTests
    {
        [Fact]
        public void ChangeStatus_ShouldUpdateStatusAndReturnMessage()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "TestUser"
            };
            var newStatus = TicketStatus.InProgress;
            var updatedBy = "TestUser2";

            ticket.ChangeStatus(newStatus, updatedBy);

            Assert.Equal(newStatus, ticket.Status);
            Assert.Equal(updatedBy, ticket.UpdatedBy);
            Assert.True((DateTime.UtcNow - ticket.UpdatedAt).TotalSeconds < 1);
        }

        [Fact]
        public void ChangeStatus_ShouldThrowException_WhenOpenToClosed()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "TestUser"
            };
            var newStatus = TicketStatus.Closed;
            var updatedBy = "TestUser2";

            Assert.Throws<DomainException>(() => ticket.ChangeStatus(newStatus, updatedBy));
        }

        [Fact]
        public void ChangeStatus_ShouldUpdateStatus_FromOpenToCanceled()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "TestUser"
            };
            var newStatus = TicketStatus.Canceled;
            var updatedBy = "TestUser2";

            ticket.ChangeStatus(newStatus, updatedBy);

            Assert.Equal(newStatus, ticket.Status);
            Assert.Equal(updatedBy, ticket.UpdatedBy);
        }

        [Fact]
        public void ChangeStatus_ShouldUpdateStatus_FromInProgressToResolved()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                Status = TicketStatus.InProgress
            };
            var newStatus = TicketStatus.Resolved;
            var updatedBy = "TestUser2";

            ticket.ChangeStatus(newStatus, updatedBy);

            Assert.Equal(newStatus, ticket.Status);
            Assert.Equal(updatedBy, ticket.UpdatedBy);
        }

        [Fact]
        public void ChangeStatus_ShouldUpdateStatus_FromResolvedToReopened()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                Status = TicketStatus.Resolved
            };
            var newStatus = TicketStatus.Reopened;
            var updatedBy = "TestUser2";

            ticket.ChangeStatus(newStatus, updatedBy);

            Assert.Equal(newStatus, ticket.Status);
            Assert.Equal(updatedBy, ticket.UpdatedBy);
        }

        [Fact]
        public void ChangeStatus_ShouldThrowException_WhenClosedToReopened()
        {
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "TestUser",
                Status = TicketStatus.Closed
            };
            var newStatus = TicketStatus.Reopened;
            var updatedBy = "TestUser2";

            Assert.Throws<DomainException>(() => ticket.ChangeStatus(newStatus, updatedBy));
        }
    }
}
