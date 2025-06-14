using SampleApp.Core.Contracts.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Core.Contracts.Students.Exceptions
{
    public class NoHomeAddressException : BadRequestException
    {
        public NoHomeAddressException() : base("Home address is not provided!") { }
    }
}
