using AngryBirds.Logic;
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
using System.Windows.Threading;

namespace AngryBirds
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic logic;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            logic = new GameLogic();
            logic.GameOver += Logic_GameOver;
            logic.Victory += Logic_Victory;
            display.SetupModel(logic);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(41);
            dt.Tick += Dt_Tick;
            dt.Start();

            DispatcherTimer et = new DispatcherTimer();
            et.Interval = TimeSpan.FromSeconds(10);
            et.Tick += Et_tick;
            et.Start();


            display.SetupSizes(new Size(grid.ActualWidth,grid.ActualHeight));
            logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
        }

        private void Logic_Victory(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Ernie does not bother you anymore!");
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void Logic_GameOver(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("You got overwhelmed!");
            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }

        private void Dt_Tick(object? sender, EventArgs e)
        {
            logic.TimeStep();
        }

        private void Et_tick(object? sender, EventArgs e)
        {
            logic.ErnieSpawner();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
                if (logic != null)
                {
                    display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
                    logic.SetupSizes(new System.Windows.Size((int)grid.ActualWidth, (int)grid.ActualHeight));
                }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                logic.mousePos = Mouse.GetPosition(display);
                logic.Control(GameLogic.Controls.Shoot);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
