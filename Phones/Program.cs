using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Phones
{
    public abstract class Phone
    {
        private string phoneNumber;
        public string PhoneNumber { get; set; }

        public string address;
        public abstract void Connect();
        public abstract void Disconnect();
    }
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }
    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {
        }
        public void MakeCall()
        {
        }
        public void HangUp()
        {
        }
        public override void Connect()
        {
        }
        public override void Disconnect()
        {
        }
    }
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {
        }
        public void MakeCall()
        {
        }
        public void HangUp()
        {
        }
        public override void Connect()
        {
        }
        public override void Disconnect()
        {
        }
    }
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;

        private byte whichDrWho;
        public byte WhichDrWho { get; }

        private string femaleSideKick;
        public string FemaleSideKick { get; }

        public double exteriorSurfaceArea;
        public double interiorVolume;

        public void TimeTravel()
        {
        }

        public static bool operator ==(Tardis object1, Tardis object2)
        {
            return (object1.whichDrWho == object2.whichDrWho);
        }
        public static bool operator !=(Tardis object1, Tardis object2)
        {
            return (object1.whichDrWho != object2.whichDrWho);
        }
        public static bool operator <(Tardis object1, Tardis object2)
        {
            if(object2.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (object1.whichDrWho < object2.whichDrWho);
            }
        }
        public static bool operator >(Tardis object1, Tardis object2)
        {
            if(object1.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (object1.whichDrWho > object2.whichDrWho);
            }
        }
        public static bool operator <=(Tardis object1, Tardis object2)
        {
            if (object2.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (object1.whichDrWho <= object2.whichDrWho);
            }
        }
        public static bool operator >=(Tardis object1, Tardis object2)
        {
            if (object1.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return (object1.whichDrWho >= object2.whichDrWho);
            }
        }
    }
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {
        }
        public void CloseDoor()
        {
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Tardis one = new Tardis();
            PhoneBooth two = new PhoneBooth();
            UsePhone(one);
            UsePhone(two);
        }
        static void UsePhone(object obj)
        {
            PhoneInterface pI = (PhoneInterface)obj;
            pI.MakeCall();
            pI.HangUp();
            if (obj.GetType().Equals("Tardis"))
            {
                Tardis t = (Tardis)obj;
                t.TimeTravel();
            }
            else if (obj.GetType().Equals("PhoneBooth"))
            {
                PhoneBooth pB = (PhoneBooth)obj;
                pB.CloseDoor();
            }
        }
    }
}