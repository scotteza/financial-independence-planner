using FinancialIndependencePlanner.IncomeStreams;
using System.Collections.Generic;

namespace FinancialIndependencePlanner
{
    public class Planner
    {
        private readonly Printer _printer;
        private readonly List<IncomeStream> _incomeStreams;

        public Planner(Printer printer)
        {
            _printer = printer;
            _incomeStreams = new List<IncomeStream>();
        }

        public void AddIncomeStream(IncomeStream incomeStream)
        {
            _incomeStreams.Add(incomeStream);
        }

        public void Plan(YearAndMonth startDate, YearAndMonth endDate)
        {
            var range = new YearsAndMonthsForRangeFinder().GetYearsAndMonthsForRange(startDate, endDate);

            foreach (var yearAndMonth in range)
            {

            }
        }
    }
}
