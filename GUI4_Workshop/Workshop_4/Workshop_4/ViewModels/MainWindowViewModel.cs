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

namespace Workshop_4.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IJobLogic logic;
        public ObservableCollection<Job> Jobs { get; set; }
        public ObservableCollection<Job> JobsOrdered { get; set; }

        private Job selectedFromJobs;

        public Job SelectedFromJobs
        {
            get { return SelectedFromJobs; }
            set
            {
                SetProperty(ref selectedFromJobs, value);
                (AddToJobsOrderedCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditJobCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Job selectedFromJobsOrdered;

        public Job SelectedFromJobsOrdered
        {
            get { return selectedFromJobsOrdered; }
            set
            {
                SetProperty(ref selectedFromJobsOrdered, value);
                (RemoveFromJobsOrderedCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditJobOrderedCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        ICommand AddToJobsOrderedCommand { get; set; }
        ICommand EditJobCommand { get; set; }
        ICommand RemoveFromJobsOrderedCommand { get; set; }
        ICommand EditJobOrderedCommand { get; set; }


        public int AllCost
        {
            get
            {
                return logic.AllCost;
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel() :this(IsInDesignMode ? null :Ioc.Default.GetService<IJobLogic>())
        {

        }
        

        public MainWindowViewModel (IJobLogic logic)
        {
            this.logic = logic;
            Jobs= new ObservableCollection<Job>();
            JobsOrdered = new ObservableCollection<Job>();

            Jobs.Add(new Job()
            {
                Name = "Kertész",
                Amount = 100,
                Unit = "nm"
            }); ;


            JobsOrdered.Add(Jobs[0].GetCopy());

            logic.SetupCollections(Jobs,JobsOrdered);

            AddToJobsOrderedCommand = new RelayCommand(
                () => logic.AddToJobs(selectedFromJobs)
                );

            Messenger.Register<MainWindowViewModel, string, string>(this, "JobInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
            });
        }
    }
}
