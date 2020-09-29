using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_PE14
{
    class Program
    {
        static void Main(string[] args)
        {
			Cow cow = new Cow();
			Crow crow = new Crow();
			MyMethod(cow);
			MyMethod(crow);
        }
		public static void MyMethod(object myObject)
		{
			IAnimal animal = (IAnimal)myObject;
			animal.Noise();
		}
    }
	public interface IAnimal
	{
		void Noise();
	}
	public class Cow : IAnimal
	{
		public void Noise()
		{
			Console.WriteLine("Moo!");
		}
	}
	public class Crow : IAnimal
	{
		public void Noise()
		{
			Console.WriteLine("Ca-caw!");
		}
	}

}