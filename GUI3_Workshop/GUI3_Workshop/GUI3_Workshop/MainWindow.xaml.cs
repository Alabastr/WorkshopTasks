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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI3_Workshop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModel).AddToArmy();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ViewModel).RemoveFromArmy();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
                TrooperEditor te = new TrooperEditor((this.DataContext as ViewModel).SelectedFromTrooper);
                te.ShowDialog();
        }
    }
}
