using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_4.Models;

namespace Workshop_4.ViewModels
{
    public class SpecificsWindowViewModel
    {
        public Job Actual { get; set; }

        public void Setup(Job job)
        {
            this.Actual = job;
        }

        public SpecificsWindowViewModel()
        {

        }
    }
}
