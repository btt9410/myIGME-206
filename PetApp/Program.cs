using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PetApp
{
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }
    public class Cat : Pet, ICat
    {
        public override void Eat()
        {
            Console.WriteLine(this.Name + ": Give me foooooood!");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + ": Give me a toy!");
        }
        public void Scratch()
        {
            Console.WriteLine(this.Name + ": Who are you? Go away.");
        }
        public void Purr()
        {
            Console.WriteLine(this.Name + ": Pay attention to me!");
        }
        public override void GotoVet()
        {
            Console.WriteLine(this.Name + ": Can't go to the vet, I'm busy today.");
        }
        public Cat()
        {
        }
    }
    public class Dog : Pet, IDog
    {
        public string license;
        public override void Eat()
        {
            Console.WriteLine(this.Name + ": Psst, hey, is it time for food yet?");
        }
        public override void Play()
        {
            Console.WriteLine(this.Name + ": Throw the ball! Please! Throw it!");
        }
        public void Bark()
        {
            Console.WriteLine(this.Name + ": That mailman is trying to break in and kill you! I'll protect you! BARK!");
        }
        public void NeedWalk()
        {
            Console.WriteLine(this.Name + ": Take me outside!");
        }
        public override void GotoVet()
        {
            Console.WriteLine(this.Name + ": Oh boy, we're going somewhere? I hope it's a park and not a vet!");
        }
        public Dog(string szName, int nAge, string szLicense) : base(szName, nAge)
        {
            Name = szName;
            age = nAge;
        }
    }
    public abstract class Pet
    {
        private string name;
        public int age;
        public string Name;
        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();
        public Pet()
        {
        }
        public Pet(string name, int age)
        {
            this.name = Name;
            this.age = age;
        }
    }
    public class Pets
    {
        List<Pet> petList = new List<Pet>();
        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }
                return (returnVal);
            }
            set
            {
                if (nPetEl < petList.Count)
                {
                    petList[nPetEl] = value;
                }
                else
                {
                    petList.Add(value);
                }
            }
        }
        public int Count { get; }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;
            Pets pets = new Pets();
            Random rand = new Random();

            for (int x = 0; x < 50; x++)
            {
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");
                        Console.Write("Dog's Name >> ");
                        string name = Console.ReadLine();
                        bool valid = false;
                        int age = 0;
                        do
                        {
                            Console.Write("Dog's Age >> ");
                            string sAge = Console.ReadLine();
                            try
                            {
                                age = int.Parse(sAge);
                                valid = true;
                            }
                            catch
                            {
                                valid = false;
                                Console.WriteLine("Please enter a valid integer for age.");
                            }
                        } while (valid == false);
                        Console.Write("Dog's License >> ");
                        string license = Console.ReadLine();
                        dog = new Dog(name, age, license);
                        dog.license = license;
                        thisPet = dog;
                        pets.Add(thisPet);
                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        Console.Write("Cat's Name >> ");
                        string name = Console.ReadLine();
                        bool valid = false;
                        int age = 0;
                        do
                        {
                            Console.Write("Cat's Age >> ");
                            string sAge = Console.ReadLine();
                            try
                            {
                                age = int.Parse(sAge);
                                valid = true;
                            }
                            catch
                            {
                                valid = false;
                                Console.WriteLine("Please enter a valid integer for age.");
                            }
                        } while (valid == false);
                        cat = new Cat();
                        cat.Name = name;
                        cat.age = age;
                        thisPet = cat;
                        pets.Add(thisPet);
                    }
                }
                else if (rand.Next(1, 11) != 1 && thisPet != null)
                {
                    if (thisPet.GetType() == typeof(Dog))
                    {
                        iDog = (IDog)thisPet;
                        switch (rand.Next(1, 6))
                        {
                            case 1:
                                iDog.Eat();
                                break;
                            case 2:
                                iDog.Play();
                                break;
                            case 3:
                                iDog.Bark();
                                break;
                            case 4:
                                iDog.NeedWalk();
                                break;
                            case 5:
                                iDog.GotoVet();
                                break;
                        }
                    }
                    else if (thisPet.GetType() == typeof(Cat))
                    {
                        iCat = (ICat)thisPet;
                        switch (rand.Next(1, 5))
                        {
                            case 1:
                                iCat.Eat();
                                break;
                            case 2:
                                iCat.Play();
                                break;
                            case 3:
                                iCat.Scratch();
                                break;
                            case 4:
                                iCat.Purr();
                                break;
                        }
                    }
                    else
                    {
                        thisPet = pets[rand.Next(0, pets.Count)];
                        if (thisPet == null)
                        {
                            x--;
                        }
                    }
                }
            }
        }
    }
}