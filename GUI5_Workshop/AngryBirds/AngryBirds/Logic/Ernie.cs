using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AngryBirds.Logic
{
    internal class Ernie
    {
        public System.Windows.Point Center { get; set; }
        public Vector Speed { get; set; }

        static Random r = new Random();

        private int Randomizer(int min, int max)
        {
            int rnd = 0;
            do
            {
                rnd = r.Next(min, max + 1);
            } while (rnd == 0);
            return rnd;
        }
        public Ernie(Size area)
        {
            Center = new System.Windows.Point((int)area.Width - 25, r.Next(25, (int)area.Height - 25));
            Speed = new Vector(Randomizer(-10, -1), Randomizer(-10, 6));
        }

        public void Move(System.Windows.Size area)
        {
            System.Windows.Point newCenter =
                new System.Windows.Point(Center.X + Speed.X, Center.Y + Speed.Y);
            if (newCenter.X >= 0 && newCenter.X <= area.Width &&
                newCenter.Y >= 0 && newCenter.Y <= area.Height)
            {
                Center = newCenter;
                if (newCenter.X<=(area.Width-(area.Width-110)) && newCenter.Y>=area.Height-110)
                {
                    Speed = new Vector(Speed.Y*r.Next(1,2), Speed.X * -1);
                }
            }
            else
            {
                Speed = new Vector(Speed.Y,Speed.X*-1);
            }


        }

    }
}
