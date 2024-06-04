using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Common.Exceptions
{
    public class RegistrationFailureException : Exception
    {
        public RegistrationFailureException(string? message) : base(message)
        {
        }
    }
}
