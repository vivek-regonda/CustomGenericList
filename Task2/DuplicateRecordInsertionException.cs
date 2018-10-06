using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class DuplicateRecordInsertionException : Exception
    {
        private string p;

        public DuplicateRecordInsertionException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
            Console.WriteLine(p);
        }

    }
}
