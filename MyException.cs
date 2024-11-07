using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241107_ExceptionsDemo
{
    internal class MyException: Exception
    {
        public string InputString { get; private set; }

        public MyException()
        {
        }

        public MyException(string message)
            : base(message)
        {
            
        }

        public MyException(string message, Exception innerException)
           : base(message, innerException)
        {

        }

        public MyException(string message, Exception innerException, string inputString)
           : base(message, innerException)
        {
            InputString = inputString;
        }
    }
}
