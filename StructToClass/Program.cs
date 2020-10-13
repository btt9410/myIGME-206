using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructToClass
{
    public class Friend
    {
        public string name;
        public string greeting;
        public string address;
        public DateTime birthDate;
        public Friend()
        {
        }
        public Friend(Friend f)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Friend friend = new Friend();

            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthDate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY 12202";

            Friend enemy = new Friend(friend);

            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender. Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");

        }
    }
}