using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GUI3_Workshop
{
    internal class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        public int Money
        {
            get
            {
               // return this.Army.Sum(t => t.Cost * t.Power * t.Vitality);

                int sum = 0;

                if (Army!=null)
                {
                    foreach (var item in Army)
                    {
                        sum += item.Power * item.Vitality * item.Cost;
                    }
                }
                else
                {
                    sum = 0;
                }
                return sum;
            }
        }

        public BindingList<Trooper> Troopers { get; set; }

        public BindingList<Trooper> Army { get; set; }

        private Trooper selectedFromTrooper;

        public Trooper SelectedFromTrooper
        {
            get { return selectedFromTrooper; }
            set { selectedFromTrooper = value; }
        }

        private Trooper memberSelected;

        public Trooper MemberSelected
        {
            get { return memberSelected; }
            set { memberSelected = value; }
        }


        public ViewModel()
        {
            Troopers = new BindingList<Trooper>();
            Army = new BindingList<Trooper>();

            Troopers.Add(new Trooper()
            {
                Type = "marine",
                Power = 8,
                Vitality = 6,
                Cost = 6
            });
            Troopers.Add(new Trooper()
            {
                Type = "pilot",
                Power = 7,
                Vitality = 3,
                Cost = 10
            });
            Troopers.Add(new Trooper()
            {
                Type = "infantry",
                Power = 6,
                Vitality = 8,
                Cost = 10
            });
            Troopers.Add(new Trooper()
            {
                Type = "sniper",
                Power = 3,
                Vitality = 3,
                Cost = 7
            });
            Troopers.Add(new Trooper()
            {
                Type = "engineer",
                Power = 5,
                Vitality = 6,
                Cost = 8
            });

        }

        public void AddToArmy()
        {
            if (SelectedFromTrooper != null)
            {
                Army.Add(SelectedFromTrooper.GetCopy());
                OnPropertyChanged("Money");
            }
        }

        public void RemoveFromArmy()
        {
            if (MemberSelected != null)
            {
                Army.Remove(MemberSelected);
                OnPropertyChanged("Money");
            }
        }
    }
}
