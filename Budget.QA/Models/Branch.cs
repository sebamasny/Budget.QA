namespace Budget.Models
{
    public class Branch : Address
    {
        public string Name { get; set; }
        public string BranchCode { get; set; }
        public string DepartmentCode { get; set; }
        public string CompanyCode { get; set; }
    }
}