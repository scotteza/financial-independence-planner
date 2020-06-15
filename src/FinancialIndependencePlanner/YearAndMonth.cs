namespace FinancialIndependencePlanner
{
    public class YearAndMonth
    {
        public int Year { get; }
        public int Month { get; }

        public YearAndMonth(int year, int month)
        {
            Year = year;
            Month = month;
        }

        public bool IsLessThanOrEqualTo(YearAndMonth compareTo)
        {
            var thisInMonths = (Year * 12) + Month;
            var compareToInMonths = (compareTo.Year * 12) + compareTo.Month;

            return thisInMonths <= compareToInMonths;
        }

        public YearAndMonth AddOneMonth()
        {
            if (Month == 12)
            {
                return new YearAndMonth(Year + 1, 1);
            }

            return new YearAndMonth(Year, Month + 1);
        }
    }
}
