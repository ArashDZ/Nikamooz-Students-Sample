using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Core.RequestResponse.Students
{
    public class StudentListModel
    {
        public int Id { get; set; }
        public short StudentNo { get; set; }
        public byte Grade { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
