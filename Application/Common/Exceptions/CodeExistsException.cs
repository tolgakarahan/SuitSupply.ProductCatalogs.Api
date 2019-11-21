using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class CodeExistsException : Exception
    {
        public CodeExistsException(string name, string code) 
            : base($"The code: '{code}' already exists on {name}")
        {

        }
    }
}
