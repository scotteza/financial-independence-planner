using Xunit;

namespace FinancialIndependencePlanner.Test.Unit
{
    public class YearAndMonthShould
    {
        [Fact(Skip = "Not implemented")]
        public void Not_Allow_A_Month_Less_Than_1()
        {

        }

        [Fact(Skip = "Not implemented")]
        public void Not_Allow_A_Month_Greater_Than_12()
        {

        }

        [Fact]
        public void Detect_A_Year_And_Month_That_Is_Equal_To_Another()
        {
            var yearAndMonth = new YearAndMonth(2012, 6);
            var sameYearAndMonth = new YearAndMonth(2012, 6);


            var result = yearAndMonth.IsLessThanOrEqualTo(sameYearAndMonth);


            Assert.True(result);
        }

        [Fact]
        public void Detect_A_Year_And_Month_That_Is_Lower_Than_Another_In_The_Same_Year()
        {
            var now = new YearAndMonth(2012, 5);
            var theFuture = new YearAndMonth(2012, 6);


            var result = now.IsLessThanOrEqualTo(theFuture);


            Assert.True(result);
        }

        [Fact]
        public void Detect_A_Year_And_Month_That_Is_Not_Lower_Than_Another_In_The_Same_Year()
        {
            var now = new YearAndMonth(2012, 6);
            var thePast = new YearAndMonth(2012, 5);


            var result = now.IsLessThanOrEqualTo(thePast);


            Assert.False(result);
        }

        [Fact]
        public void Detect_A_Year_And_Month_That_Is_Lower_Than_Another_In_A_Different_Year()
        {
            var now = new YearAndMonth(2012, 5);
            var theFuture = new YearAndMonth(2021, 5);


            var result = now.IsLessThanOrEqualTo(theFuture);


            Assert.True(result);
        }

        [Fact]
        public void Detect_A_Year_And_Month_That_Is_Not_Lower_Than_Another_In_A_Different_Year()
        {
            var now = new YearAndMonth(2012, 5);
            var thePast = new YearAndMonth(2001, 5);


            var result = now.IsLessThanOrEqualTo(thePast);


            Assert.False(result);
        }

        [Fact]
        public void Add_A_Single_Month()
        {
            var now = new YearAndMonth(2012, 6);


            var result = now.AddOneMonth();


            Assert.Equal(2012, result.Year);
            Assert.Equal(7, result.Month);
        }

        [Fact]
        public void Add_A_Single_Month_In_December()
        {
            var now = new YearAndMonth(2012, 12);


            var result = now.AddOneMonth();


            Assert.Equal(2013, result.Year);
            Assert.Equal(1, result.Month);
        }
    }
}
