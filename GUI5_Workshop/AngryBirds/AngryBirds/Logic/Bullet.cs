using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AngryBirds.Logic
{
    internal class Bullet
    {
        public Bullet(System.Windows.Point center, Vector speed)
        {
            Center = center;
            Speed = speed;
        }

        public System.Windows.Point Center { get; set; }

        public Vector Speed { get; set; }

        public bool Move(System.Windows.Size area)
        {
            System.Windows.Point newCenter =
                new System.Windows.Point(Center.X+Speed.X,Center.Y+Speed.Y);
            if (newCenter.X >=0 && newCenter.X <= area.Width &&
                newCenter.Y >=0 && newCenter.Y <=area.Height)
            {
                Center = newCenter;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
