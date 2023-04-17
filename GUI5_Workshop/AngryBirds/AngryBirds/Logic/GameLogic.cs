using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AngryBirds.Logic
{
    internal class GameLogic : IGameModel
    {
        public System.Windows.Point mousePos;

        private int berniesAlive = 1;

        private int berniesKilled;

        public event EventHandler Changed;

        public event EventHandler GameOver;

        public event EventHandler Victory;

        public List<Bullet> Bullets { get; set; }
        public List<Ernie> Ernies { get; set; }

        System.Windows.Size area;

        static Random r = new Random();
        public void SetupSizes(System.Windows.Size area)
        {
            this.area = area;
            Bullets = new List<Bullet>();
            Ernies = new List<Ernie>();
            Ernies.Add(new Ernie(area));

        }

        public GameLogic()
        {
           
        }
        public enum Controls
        {
            Shoot
        }
        public void Control(Controls control)
        {
            switch (control)
            {
                case Controls.Shoot:
                    NewShoot();
                    break;
            }
        }

        private void NewShoot()
        {
            double sideALength = 0;
            double sideBLength = 0;
            if (mousePos.X < area.Width / 2 && mousePos.Y < area.Height / 2)
            {
                sideALength = (area.Width - (area.Width - mousePos.X) - 40);
                sideBLength = area.Height - mousePos.Y - 40;
            }
            else if (mousePos.X < area.Width / 2 && mousePos.Y > area.Height / 2 && mousePos.Y <= area.Height)
            {
                sideALength = (area.Width - (area.Width - mousePos.X) - 40);
                sideBLength = (area.Height - mousePos.Y - 40);
            }
            else if (mousePos.X > area.Width / 2 && mousePos.Y < area.Height / 2)
            {
                sideALength = (area.Width - (area.Width - mousePos.X) + 40);
                sideBLength = area.Height - mousePos.Y - 40;
            }
            else
            {
                sideALength = (area.Width - (area.Width - mousePos.X) + 40);
                sideBLength = (mousePos.Y - area.Height + 40) * -1;
            }

            double angle = (Math.Atan(sideBLength / sideALength)) * (180 / Math.PI);




            if (angle < 0 && angle > -45)
            {
                angle = 0;
            }
            else if (angle < -45)
            {
                angle = 90;
            }

            double rad = (angle - 90) * (Math.PI / 180);

            double dx = Math.Cos(rad);
            double dy = Math.Sin(rad);

            dx = dx * 20;
            dy = dy * 20;

            Bullets.Add(new Bullet(new System.Windows.Point(area.Width - (area.Width - 40), area.Height - 40),
                new System.Windows.Vector(-dy, -dx)));
        }

        public void TimeStep()
        {
            for (int i = 0; i < Bullets.Count; i++)
            {
                bool inside = Bullets[i].Move(area);
                if (!inside)
                {
                    Bullets.RemoveAt(i);
                }
            }
            if (berniesAlive >= 15)
            {
                GameOver?.Invoke(this, null);
            }

            if (berniesKilled>=10)
            {
                Victory?.Invoke(this, null);
            }
            for (int i = 0; i < Ernies.Count; i++)
            {
            
                if (Ernies[i]!=null)
                {
                    Ernies[i].Move(area);

                    foreach (var item in Bullets)
                    {
                        Rect bulletRect = new Rect(item.Center.X - 3, item.Center.Y - 3, 5, 5);
                        Rect ernieRect = new Rect(Ernies[i].Center.X - 12, Ernies[i].Center.Y - 12, 25, 25);

                        if (bulletRect.IntersectsWith(ernieRect))
                        {
                            Ernies.RemoveAt(i);
                            berniesAlive--;
                            berniesKilled++;
                            Ernies.Add(new Ernie(new System.Windows.Size(area.Width*2,area.Height)));
                        }
                    }
                }

            }




            Changed?.Invoke(this, null);
        }

        internal void ErnieSpawner()
        {
            
            var numSpawned = r.Next(1, 4);

            if (numSpawned == 1)
            {
                berniesAlive++;
                Ernies.Add(new Ernie(area));
            }
            else if (numSpawned == 2)
            {
                berniesAlive = berniesAlive + 2;
                Ernies.Add(new Ernie(area));
                Ernies.Add(new Ernie(area));
            }
            else
            {
                berniesAlive = berniesAlive + 3;
                Ernies.Add(new Ernie(area));
                Ernies.Add(new Ernie(area));
                Ernies.Add(new Ernie(area));
            }


            Changed?.Invoke(this, null);
        }
    }
}
