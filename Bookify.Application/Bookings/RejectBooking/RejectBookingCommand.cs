using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Bookings.RejectBooking;

public sealed record RejectBookingCommand(Guid BookingId) : ICommand;
