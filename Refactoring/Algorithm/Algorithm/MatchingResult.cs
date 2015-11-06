using System;

namespace Algorithm
{
    public class MatchingResult
    {
        public Person FirstPerson { get; set; }
        public Person SecondPerson { get; set; }
        public TimeSpan AgeDifference { get; set; }
    }
}