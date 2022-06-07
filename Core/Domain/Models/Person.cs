namespace FluentValidationCustomRule.Core.Domain.Models
{
    public class Person
    {
        public string Name { get; set; }
        public AddressType AddressType { get; set; }
        public string Address { get; set; }
    }
}