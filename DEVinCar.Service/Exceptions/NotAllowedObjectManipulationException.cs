namespace DEVinCar.Service.Exceptions
{
    public class NotAllowedObjectManipulationException : Exception
    {
        public NotAllowedObjectManipulationException(string? message) : base(message)
        {
        }
    }
}
