using Bookify.Application.Abstraction.Messaging;

namespace Bookify.Application.Bookings.CompleteBooking;

public sealed record CompleteBookingCommand(Guid BookingId) : ICommand;
