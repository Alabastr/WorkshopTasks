using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_4.Models
{
    public class Job : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private int price;

        public int Price
        {
            get { return price; }
            set { SetProperty(ref amount, value); }
        } 


        private int amount;
        public int Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        private string unit;
        public string Unit
        {
            get { return unit; }
            set { SetProperty(ref unit, value); }
        }

        public int Cost
        {
            get
            {
                return price * amount;
            }
        }

        public Job GetCopy()
        {
            return new Job()
            {
                Name = this.name,
                Price = this.price,
                Unit = this.unit,
                Amount = this.Amount,
            };
        }
    }

}

