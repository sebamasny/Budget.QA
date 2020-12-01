using AutomationResources;
using Budget.Helpers.EntryPoints;
using Budget.Models;
using NUnit.Framework;
using static Budget.Enums.ValidationTypes;

namespace Budget.Tests
{
    public class WindTests : BaseTest
    {
        public WindTests(BrowserType browserType) : base(browserType)
        {
        }

        [Test]
        [Category("SmokeTests")]
        [Description("TC01 - Adding new branch")]
        [Property("Author", "SebastianMasny")]
        public void AddingNewBranch()
        {
            var branch = BranchBuilder.CreateDefault().Build();

            Driver.LogBudgetUser();
            Driver.BasePage()
                .NavMenu.OpenManagementTab()
                .BranchesList()
                .AddNewBranch()
                .GoToPersonsList(1)
                .AddPersons()
                .GoToPersonsList()
                .AddPersons(3)
                .SaveBranch(branch)
                .SearchBranch(branch);
        }

        [Test]
        [Category("SmokeTests")]
        [Description("TC03 - Adding new budget")]
        [Property("Author", "SebastianMasny")]
        public void AddingNewBudget()
        {
            var budget = BudgetBuilder.CreateDefault().Build();

            Driver.LogBudgetUser();
            Driver.AnnualReportsPage()
                .GetYear(budget)
                .NewBudget()
                .FillBasicData(budget)
                .FillValuesSection(budget)
                .WorkingDays()
                .Limits(budget)
                .Validation(PercentageMax)
                .Generate();
        }

        [Test]
        [Category("SmokeTests")]
        [Description("TC02 - Adding new subcategory")]
        [Property("Author", "SebastianMasny")]
        public void AddingNewSubcategory()
        {
            var category = CategoryBuilder.CreateDefault().Build();

            Driver.LogBudgetUser();
            Driver.BasePage()
                .NavMenu.OpenManagementTab()
                .SubcategoriesList()
                .AddNewSubcategory()
                .SaveSubcategory(category)
                .SearchCategory(category);
        }
    }
}