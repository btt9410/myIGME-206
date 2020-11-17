using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _Thread
{
	public class CounterThread
	{
		public static void run()
		{
			for (int i = 0; i < 100; i++)
				Console.WriteLine("Count:  " + i);
		}

		public static void Main(string[] args)
		{
			Thread ct = new Thread(run);
			ct.Start();
			Console.ReadLine();
		}
	}
}
