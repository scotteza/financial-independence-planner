using System.Collections.Generic;

namespace FinancialIndependencePlanner
{
    public class YearsAndMonthsForRangeFinder
    {
        public List<YearAndMonth> GetYearsAndMonthsForRange(YearAndMonth start, YearAndMonth end)
        {
            var result = new List<YearAndMonth>();

            var currentYearAndMonth = new YearAndMonth(start.Year, start.Month);

            while (currentYearAndMonth.IsLessThanOrEqualTo(end))
            {
                result.Add(currentYearAndMonth);
                currentYearAndMonth = currentYearAndMonth.AddOneMonth();
            }

            return result;
        }
    }
}