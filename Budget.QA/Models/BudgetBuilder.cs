using static Budget.Helpers.Utils;

namespace Budget.Models
{
    public class BudgetBuilder
    {
        private readonly Budget _budget;

        private BudgetBuilder(Budget budget)
        {
            _budget = budget;
        }

        public static BudgetBuilder CreateDefault()
        {
            var budget = new Budget
            {
                Euro = RandomInt(1),
                Dollar = RandomInt(1),
                Inflation = RandomInt(1),
                Limit = RandomInt(2)
            };
            return new BudgetBuilder(budget);
        }

        public Budget Build()
        {
            return _budget;
        }
    }
}