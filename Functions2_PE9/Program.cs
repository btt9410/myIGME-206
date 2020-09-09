using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions2_PE9
{
    class Program
    {
        delegate string ConsoleRead();
        static void Main(string[] args)
        {
            ConsoleRead read;
            read = new ConsoleRead(Console.ReadLine);
        }
    }
}
