using SampleApp.Core.Domain.Students.Enums;

namespace SampleApp.Core.RequestResponse.Addresses
{
    public class AddressViewModel
    {
        public AddressType AddressType { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Alley { get; set; }
        public string? BuildingNo { get; set; }
    }
}
