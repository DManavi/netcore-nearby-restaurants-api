using System;

namespace NearbyRestaurants.Domain
{
    public class OpeningHour
    {
        /// <summary>
        /// Day of the week that restaurant is working on
        /// </summary>
        public DayOfWeek Day { get; private set; }

        /// <summary>
        /// Time that restaurant starts working
        /// </summary>
        public TimeSpan From { get; private set; }

        /// <summary>
        /// Time that restaurant closes on
        /// </summary>
        public TimeSpan To { get; private set; }

        /// <summary>
        /// Create a new instance of opening hours
        /// </summary>
        /// <param name="day">Day of the week</param>
        /// <param name="from">Start working from</param>
        /// <param name="to">Continue working to</param>
        /// <returns>Opening hours</returns>
        public static OpeningHour Create(DayOfWeek day, TimeSpan from, TimeSpan to) => new OpeningHour()
        {
            Day = day,
            From = from,
            To = to
        };
    }
}