namespace DEVinCar.Service.Exceptions
{
    public class EqualOrLowerThanZeroException : Exception
    {
        public EqualOrLowerThanZeroException(string? message) : base(message)
        {
        }
    }
}
