using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films
{
    public abstract class Film
    {
        public string name;
        public string director;

        public abstract void PowerOn();
        public virtual void PowerOff()
        {
        }
    }
    public interface IControl
    {
        void Play();
        void Pause();
        void FastForward();
    }
    public interface IFilm
    {
        void Opening();
        void Credits();
    }
    public class ActionFilm : Film, IControl, IFilm
    {
        public int budget;
        public override void PowerOn()
        {
        }
        public override void PowerOff()
        {
        }
        public void Play()
        {
        }
        public void Pause()
        {
        }
        public void FastForward()
        {
        }
        public void Opening()
        {
        }
        public void Credits()
        {
        }
    }
    public class MysteryFilm : Film, IControl, IFilm
    {
        public string detectiveName;
        public override void PowerOn()
        {
        }
        public override void PowerOff()
        {
        }
        public void Play()
        {
        }
        public void Pause()
        {
        }
        public void FastForward()
        {
        }
        public void Opening()
        {
        }
        public void Credits()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ActionFilm avengers = new ActionFilm();
            MysteryFilm orientExpress = new MysteryFilm();
            MyMethod(avengers);
            MyMethod(orientExpress);
        }
        static void MyMethod(object obj)
        {
            IControl control = (IControl)obj;
            control.Play();
            control.Pause();
            control.FastForward();

            IFilm film = (IFilm)obj;
            film.Opening();
            film.Credits();
        }
    }
}
