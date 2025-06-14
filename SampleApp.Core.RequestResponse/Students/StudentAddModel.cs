using Microsoft.AspNetCore.Http;
using SampleApp.Core.RequestResponse.Addresses;
using System.ComponentModel.DataAnnotations;
using Zamin.Core.RequestResponse.Commands;

namespace SampleApp.Core.RequestResponse.Students
{
    public class StudentAddModel : ICommand<StudentViewModel>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public byte Grade { get; set; }
        public AddressAddModel[]? Addresses { get; set; }
    }
}
