namespace DEVinCar.Service.Exceptions
{
    public class DuplicatedEntryException : Exception
    {
        public DuplicatedEntryException(string? message) : base(message)
        {
        }
    }
}
