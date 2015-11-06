using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public abstract class IResultSelector
    {
        public MatchingResult SelectMatching(List<MatchingResult> candidates)
        {
            return Select(candidates) ?? new MatchingResult();
        }

        protected abstract MatchingResult Select(List<MatchingResult> candidates);
    }

    public class ClosestSelector : IResultSelector
    {
        protected override MatchingResult Select(List<MatchingResult> candidates)
        {
            return candidates.OrderBy(x => x.AgeDifference).FirstOrDefault();
        }
    }

    public class FurthestSelector : IResultSelector
    {
        protected override MatchingResult Select(List<MatchingResult> candidates)
        {
            return candidates.OrderByDescending(x => x.AgeDifference).FirstOrDefault();
        }
    }
}