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
using DungeonMasterHelper.ViewModels;

namespace DungeonMasterHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel
        { get { return DataContext as MainViewModel; } }

        public MainWindow()
        {
            DataContext = new MainViewModel();

            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown(0);
        }

        private void GenerateCity_Click(object sender, RoutedEventArgs e) {
            CityGeneratorViewModel vm = new CityGeneratorViewModel() { Parent = ViewModel };
            CityGeneratorView cityGen = new CityGeneratorView() { DataContext = vm };
            cityGen.ShowDialog();
        }

        private void GenerateNPC_Click(object sender, RoutedEventArgs e) {
            CharacterGeneratorViewModel vm = new CharacterGeneratorViewModel() { Parent = ViewModel };
            NPCGeneratorView npcGen = new NPCGeneratorView() { DataContext = vm };
            npcGen.ShowDialog();
        }

    }
}
