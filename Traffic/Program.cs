using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    class Program
    {
        static void Main(string[] args)
        {
            void AddFunction(IPassengerCarrier passenger)
            {
                passenger.LoadPassenger();
                Console.WriteLine(passenger.ToString());
            }
        }
    }
}
