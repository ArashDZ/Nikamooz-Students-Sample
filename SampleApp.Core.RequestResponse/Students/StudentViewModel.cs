using SampleApp.Core.RequestResponse.Addresses;

namespace SampleApp.Core.RequestResponse.Students
{
    public class StudentViewModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public short StudentNo { get; set; }
        public byte Grade { get; set; }
        public List<AddressViewModel> Addresses { get; set; } = [];
        public string ImageUrl { get; set; } = string.Empty;
    }
}
