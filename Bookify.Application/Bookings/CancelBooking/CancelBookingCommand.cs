using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Bookings.CancelBooking;

public sealed record CancelBookingCommand(Guid BookingId) : ICommand;
