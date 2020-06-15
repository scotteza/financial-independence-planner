namespace FinancialIndependencePlanner.IncomeStreams
{
    public class SalaryIncomeStream : IncomeStream
    {
        private readonly YearAndMonth _startDate;
        private readonly decimal _monthlySalary;
        private readonly string _description;

        public SalaryIncomeStream(YearAndMonth startDate, decimal monthlySalary, string description)
        {
            _startDate = startDate;
            _monthlySalary = monthlySalary;
            _description = description;
        }
    }
}
