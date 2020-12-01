using static Budget.Helpers.Utils;

namespace Budget.Models
{
    public class BranchBuilder
    {
        private readonly Branch _branch;

        private BranchBuilder(Branch branch)
        {
            _branch = branch;
        }

        public static BranchBuilder CreateDefault()
        {
            var branch = new Branch
            {
                BranchCode = "BranchCode" + RandomInt(3),
                Name = "Automated Test Branch" + RandomString(5),
                DepartmentCode = RandomInt(2),
                CompanyCode = "Com" + RandomInt(3),
                Street = "Street" + RandomLatinString(5) + " " + RandomInt(3) + "/" + RandomInt(2),
                ZipCode = RandomInt(2) + "-" + RandomInt(3),
                City = "City" + RandomLatinString(5),
                Phone = "412445908",
                Fax = "776445789"
            };
            return new BranchBuilder(branch);
        }

        public Branch Build()
        {
            return _branch;
        }
    }
}