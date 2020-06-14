using FinancialIndependencePlanner.IncomeStreams;
using Moq;
using Xunit;

namespace FinancialIndependencePlanner.Test.Acceptance
{
    public class FinancialIndependencePlannerShould
    {
        [Fact]
        public void Write_A_Year_Worth_Of_Salary_Data()
        {
            var printer = new Mock<Printer>(MockBehavior.Strict);
            var planner = new Planner(printer.Object);

            var salaryStartDate = new YearAndMonth(2012, 01);
            var salaryIncomeStream = new SalaryIncomeStream(salaryStartDate, 2000, "Bob's salary");
            planner.AddIncomeStream(salaryIncomeStream);

            var seq = new MockSequence();

            printer.InSequence(seq).Setup(o => o.Print("2020-04"));
            printer.InSequence(seq).Setup(o => o.Print("Income: Bob's salary"));
            printer.InSequence(seq).Setup(o => o.Print("Amount: 2000"));
            printer.InSequence(seq).Setup(o => o.Print("Cash in bank: 2000"));

            printer.InSequence(seq).Setup(o => o.Print("2020-05"));
            printer.InSequence(seq).Setup(o => o.Print("Income: Bob's salary"));
            printer.InSequence(seq).Setup(o => o.Print("Amount: 2000"));
            printer.InSequence(seq).Setup(o => o.Print("Cash in bank: 4000"));

            printer.InSequence(seq).Setup(o => o.Print("2020-06"));
            printer.InSequence(seq).Setup(o => o.Print("Income: Bob's salary"));
            printer.InSequence(seq).Setup(o => o.Print("Amount: 2000"));
            printer.InSequence(seq).Setup(o => o.Print("Cash in bank: 6000"));

            var plannerStartDate = new YearAndMonth(2012, 04);
            var plannerEndDate = new YearAndMonth(2012, 06);
            planner.Plan(plannerStartDate, plannerEndDate);
        }
    }
}
