using Domain.Entities;

namespace Domain.Tests.Entities
{
    public class TicketTests
    {
        [Fact]
        public void ChangeStatus_ShouldUpdateStatusAndReturnMessage()
        {
            // Arrange
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Test Ticket",
                Description = "Test Description",
                CreatedAt = DateTime.Now,
                CreatedBy = "TestUser",
                UpdatedAt = DateTime.Now,
                UpdatedBy = "TestUser"
            };
            var newStatus = TicketStatus.InProgress;
            var updatedBy = "TestUser2";
            // Act
            var result = ticket.ChangeStatus(newStatus, updatedBy);
            // Assert
            Assert.Equal(newStatus, ticket.Status);
            Assert.Equal("Status changed to InProgress", result);
            Assert.Equal(updatedBy, ticket.UpdatedBy);
            Assert.True((DateTime.Now - ticket.UpdatedAt).TotalSeconds < 1);
        }
    }
}
