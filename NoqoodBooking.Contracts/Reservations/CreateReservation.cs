namespace NoqoodBooking.Contracts.Reservations
{
    public record CreateReservationRequest(string ReservedBy, string CustomerName, DateTime ReservationDate, string Notes, Guid TripId)
    {
    }
}
