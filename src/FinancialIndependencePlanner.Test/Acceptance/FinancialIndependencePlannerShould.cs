using System.Collections.Generic;
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
            var printer = new MockPrinter();
            var planner = new Planner(printer);

            var salaryStartDate = new YearAndMonth(2012, 01);
            var salaryIncomeStream = new SalaryIncomeStream(salaryStartDate, 2000, "Bob's salary");
            planner.AddIncomeStream(salaryIncomeStream);


            var plannerStartDate = new YearAndMonth(2012, 04);
            var plannerEndDate = new YearAndMonth(2012, 06);
            planner.Plan(plannerStartDate, plannerEndDate);


            Assert.Equal(12, printer.GetPrintCount());

            Assert.Equal("2020-04", printer.GetNextPrintedLine());
            Assert.Equal("Income: Bob's salary", printer.GetNextPrintedLine());
            Assert.Equal("Amount: 2000", printer.GetNextPrintedLine());
            Assert.Equal("Cash in bank: 2000", printer.GetNextPrintedLine());

            Assert.Equal("2020-05", printer.GetNextPrintedLine());
            Assert.Equal("Income: Bob's salary", printer.GetNextPrintedLine());
            Assert.Equal("Amount: 2000", printer.GetNextPrintedLine());
            Assert.Equal("Cash in bank: 4000", printer.GetNextPrintedLine());

            Assert.Equal("2020-06", printer.GetNextPrintedLine());
            Assert.Equal("Income: Bob's salary", printer.GetNextPrintedLine());
            Assert.Equal("Amount: 2000", printer.GetNextPrintedLine());
            Assert.Equal("Cash in bank: 6000", printer.GetNextPrintedLine());
        }
    }

    public class MockPrinter : Printer
    {
        private readonly Queue<string> _printed;

        public MockPrinter()
        {
            _printed = new Queue<string>();
        }

        public void Print(string toPrint)
        {
            _printed.Enqueue(toPrint);
        }


        public int GetPrintCount()
        {
            return _printed.Count;
        }

        public string GetNextPrintedLine()
        {
            return _printed.Dequeue();
        }
    }
}
