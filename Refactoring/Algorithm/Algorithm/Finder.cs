using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        public static MatchingResult Find(List<Person> people, IResultSelector selector)
        {
            var tr = GenerateAgePairs(people);

            return selector.SelectMatching(tr);
        }

        private static List<MatchingResult> GenerateAgePairs(List<Person> people)
        {
            var tr = new List<MatchingResult>();
            
            for (var i = 0; i < people.Count - 1; i++)
            {
                for (var j = i + 1; j < people.Count; j++)
                {
                    var r = ComparePersons(people[i], people[j]);
                    tr.Add(r);
                }
            }
            return tr;
        }

        private static MatchingResult ComparePersons(Person first, Person second)
        {
            var r = new MatchingResult();
            if (first.BirthDate < second.BirthDate)
            {
                r.FirstPerson = first;
                r.SecondPerson = second;
            }
            else
            {
                r.FirstPerson = second;
                r.SecondPerson = first;
            }
            r.AgeDifference = r.SecondPerson.BirthDate - r.FirstPerson.BirthDate;
            return r;
        }
    }
}