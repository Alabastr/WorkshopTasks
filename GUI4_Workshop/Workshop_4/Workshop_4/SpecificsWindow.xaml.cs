using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Workshop_4.Models;
using Workshop_4.ViewModels;

namespace Workshop_4
{
    /// <summary>
    /// Interaction logic for SpecificsWindow.xaml
    /// </summary>
    public partial class SpecificsWindow : Window
    {
        public SpecificsWindow(Job job)
        {
            InitializeComponent();
            var vm = new SpecificsWindowViewModel();
            vm.Setup(job);
            this.DataContext = vm;
        }

        private void Vm_EditedDone(object? sender, EventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
