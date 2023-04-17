using Workshop_4.Logic;
using Workshop_4.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Automation;

namespace Workshop_4.ViewModels
{
    public class JobEditorViewModel
    {
        public Job Actual { get; set; } 

        public void Setup(Job job)
        {
            this.Actual= job;
        }

        public JobEditorViewModel()
        {

        }
    }
}
