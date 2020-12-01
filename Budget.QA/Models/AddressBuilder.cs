using static Budget.Helpers.Utils;

namespace Budget.Models
{
    public class AddressBuilder
    {
        private readonly Address _address;

        private AddressBuilder(Address address)
        {
            _address = address;
        }

        public static AddressBuilder CreateDefault()
        {
            var address = new Address
            {
                Street = "Ulica" + RandomLatinString(5),
                ZipCode = RandomInt(2) + "-" + RandomInt(3),
                City = "City" + RandomLatinString(5),
                Phone = "412-445-908",
                Fax = "(" + RandomInt(2) + ")776-445-789"
            };
            return new AddressBuilder(address);
        }

        public Address Build()
        {
            return _address;
        }
    }
}