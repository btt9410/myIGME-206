using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard_UT3
{
    public class Wizard
    {
        public string name;
        public int age;
        
        public Wizard(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // delegate
            Comparison<Wizard> sortAge = delegate (Wizard a, Wizard b)
            {
                int compare = a.age.CompareTo(b.age);
                if(compare == 0)
                {
                    return a.name.CompareTo(b.name);
                }
                return compare;
            };

            List<Wizard> wList = new List<Wizard>();

            Wizard one = new Wizard("Dante", 54);
            Wizard two = new Wizard("Nero", 24);
            Wizard three = new Wizard("V", 30);
            Wizard four = new Wizard("Vergil", 54);
            Wizard five = new Wizard("Lady", 52);
            Wizard six = new Wizard("Trish", 29);
            Wizard seven = new Wizard("Lucia", 10);
            Wizard eight = new Wizard("Morrison", 60);
            Wizard nine = new Wizard("Nico", 21);
            Wizard ten = new Wizard("Mundus", 1000);

            wList.Add(one);
            wList.Add(two);
            wList.Add(three);
            wList.Add(four);
            wList.Add(five);
            wList.Add(six);
            wList.Add(seven);
            wList.Add(eight);
            wList.Add(nine);
            wList.Add(ten);

            Console.WriteLine("Unsorted: ");
            foreach(Wizard w in wList)
            {
                Console.WriteLine(w.name + ": " + w.age);
            }

            Console.WriteLine();

            wList.Sort(sortAge);

            Console.WriteLine("Sorted: ");
            foreach(Wizard w in wList)
            {
                Console.WriteLine(w.name + ": " + w.age);
            }
            Console.WriteLine();
            // lambda
            List<Wizard> wLambList = new List<Wizard>();

            wLambList.Add(one);
            wLambList.Add(two);
            wLambList.Add(three);
            wLambList.Add(four);
            wLambList.Add(five);
            wLambList.Add(six);
            wLambList.Add(seven);
            wLambList.Add(eight);
            wLambList.Add(nine);
            wLambList.Add(ten);

            Console.WriteLine("Unsorted: ");
            foreach(Wizard w in wLambList)
            {
                Console.WriteLine(w.name + ": " + w.age);
            }

            var sortedWLambList = wLambList.OrderBy(w => w.age);

            Console.WriteLine();

            Console.WriteLine("Sorted: ");
            foreach (Wizard w in sortedWLambList)
            {
                Console.WriteLine(w.name + ": " + w.age);
            }
        }
    }

    
}
