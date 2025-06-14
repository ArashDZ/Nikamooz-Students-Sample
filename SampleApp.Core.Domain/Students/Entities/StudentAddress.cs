using SampleApp.Core.Domain.Students.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;

namespace SampleApp.Core.Domain.Students.Entities
{
    public class StudentAddress : Entity<int>
    {
        public int AddressId { get; set; }
        public int StudentId { get; set; }
        public AddressType AddressType { get; set; }
        public Student Student { get; set; }
        public Address Address { get; set; }
    }
}
