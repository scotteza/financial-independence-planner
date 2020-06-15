using Xunit;

namespace FinancialIndependencePlanner.Test.Unit
{
    public class YearsAndMonthsForRangeFinderShould
    {
        [Fact]
        public void Calculate_A_Single_Month_Range()
        {
            var finder = new YearsAndMonthsForRangeFinder();

            var start = new YearAndMonth(2012, 1);
            var end = new YearAndMonth(2012, 1);
            var result = finder.GetYearsAndMonthsForRange(start, end);

            // TODO: figure out the idiomatic way to do this in xUnit
            Assert.Equal(1, result.Count);
            Assert.Equal(2012, result[0].Year);
            Assert.Equal(1, result[0].Month);
        }

        [Fact]
        public void Calculate_Two_Consecutive_Months_In_The_Same_Year()
        {
            var finder = new YearsAndMonthsForRangeFinder();

            var start = new YearAndMonth(2012, 1);
            var end = new YearAndMonth(2012, 2);
            var result = finder.GetYearsAndMonthsForRange(start, end);

            Assert.Equal(2, result.Count);
            Assert.Equal(2012, result[0].Year);
            Assert.Equal(1, result[0].Month);
            Assert.Equal(2012, result[1].Year);
            Assert.Equal(2, result[1].Month);
        }

        [Fact]
        public void Calculate_A_Year_End_Range()
        {
            var finder = new YearsAndMonthsForRangeFinder();

            var start = new YearAndMonth(2011, 11);
            var end = new YearAndMonth(2012, 2);
            var result = finder.GetYearsAndMonthsForRange(start, end);

            Assert.Equal(4, result.Count);
            Assert.Equal(2011, result[0].Year);
            Assert.Equal(11, result[0].Month);
            Assert.Equal(2011, result[1].Year);
            Assert.Equal(12, result[1].Month);
            Assert.Equal(2012, result[2].Year);
            Assert.Equal(1, result[2].Month);
            Assert.Equal(2012, result[3].Year);
            Assert.Equal(2, result[3].Month);
        }
    }
}
