using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivedClass_PE12
{
    public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
			return base.GetString() + " (output from the derived class)";
        }
		public static void Main(string[] args)
        {
			MyDerivedClass one = new MyDerivedClass();
			Console.WriteLine(one.GetString());
        }
    }
	public class MyClass
	{
		private string myString = "test";
		public virtual string GetString()
		{
			return myString;
		}
	}

}
