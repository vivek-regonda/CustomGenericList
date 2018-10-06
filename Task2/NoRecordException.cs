using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class NoRecordException : Exception
    {
        private string p;

        public NoRecordException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
            Console.WriteLine(p);
        }
    }
}
