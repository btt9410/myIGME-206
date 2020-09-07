using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreVariables_PE8
{
    // Class Program
    // Author: Bryan Taber
    // Purpose: Three-dimensional arrays
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create a three dimensional array
        //          Add 0.1 to x and y, compute it to get z
        //          Put all three values into the array
        // Restrictions: None
        static void Main(string[] args)
        {
            double x = -1.0;
            double y = 1.0 ;
            double z;
            double[,,] computations = new double[21, 31, 3];
            for(x = -1.0; x <= 1.0; x += 0.1)
            {
                z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;
                computations[(int) x, (int) y, 0] = x;
                computations[(int) x, (int) y, 1] = y;
                computations[(int) x, (int) y, 2] = z;
            }
            x = -1.0;
            for(y = 1.0; y <= 4.0; y += 0.1)
            {
                z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;
                computations[(int)x, (int)y, 0] = x;
                computations[(int)x, (int)y, 1] = y;
                computations[(int)x, (int)y, 2] = z;
            }
        }
    }
}
