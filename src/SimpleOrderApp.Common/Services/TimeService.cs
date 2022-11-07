namespace SimpleOrderApp.Common.Services
{
    /// <summary>
    /// time related functionality
    /// </summary>
    public class TimeService : ITimeService
    {
        /// <summary>
        /// UTC
        /// </summary>
        public DateTime Now => DateTime.UtcNow;
    }
}
